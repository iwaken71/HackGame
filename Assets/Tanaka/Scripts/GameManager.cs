﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UniRx;

public class GameManager : MonoBehaviour{

	GameObject pcCamera;
	GameObject iosCamera;
	GameObject fukanCamera;
	GameObject WebUI3;
	PhotonView photonView;
	GameObject train,player;
	//ReactiveProperty<State> state = new ReactiveProperty<State>();
	State state;
	bool sceneStart = true;
	Vector3 start_pos = new Vector3(7.63f,0,12.77f);

	// trainManager
	GameObject WayPoints;
	static int index = 2;
	public string[] linePanels = new string[3];
	int currentAngle = 0; //0 to 7
	private Vector3 currentCenterPositon;
	public static float scale =1; 
	private TrainSplineMove trainSplineMove;
	// trainManager

	static public GameManager Instance = null;

	void Awake(){
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	public enum State{
		Start=0,
		Game=1,
		Rusult=2
	}

	enum Direction {
		right=-1,
		straight,
		left
	}
	// Use this for initialization
	void Start () {
		state = State.Start;
		sceneStart = true;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log (state);
		switch (state) {
		case State.Start:
			if (sceneStart) {
				if (SceneManager.GetActiveScene ().name == "Main") {
					NetworkManager.Instance.PlayerMake ();
					sceneStart = false;
					WayPoints = GameObject.FindGameObjectWithTag ("WayPoints");
					start_pos = GameObject.Find ("Start").transform.position;
					currentCenterPositon = start_pos;

				}
			}

			if (pcCamera == null) {
				pcCamera = GameObject.FindGameObjectWithTag ("PCCamera");
				//Debug.Log ("pcCamera");
			}

			if (iosCamera == null) {
				if (player != null) {
					iosCamera = player.transform.Find ("CardboardMainHack").gameObject;
					//#if UNITY_EDITOR
					//iosCamera.SetActive (false);
					//#endif
					//Debug.Log ("iosCamera");
				}
			}

			if (photonView == null) {
				/*
				if (GameObject.Find ("NetworkManager") == null) {
					photonView = (Resources.Load ("NetworkManager") as GameManager).GetComponent<PhotonView> ();
				} else {
				*/
				photonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView> ();
				Debug.Log ("photonView");

			}
			if (train == null) {
				if (GameObject.FindGameObjectWithTag ("Train")) {
					train = GameObject.FindGameObjectWithTag ("Train");
					trainSplineMove = train.GetComponent<TrainSplineMove> ();
				}
			}
			if (player == null) {
				player = GameObject.FindGameObjectWithTag ("Player");
				Debug.Log ("player");
			}

			//if (GameObject.Find ("Start") != null) {
				//start_pos = GameObject.Find ("Start").transform.position;
				//Debug.Log ("start_pos");
			//}

			if (fukanCamera == null) {
				fukanCamera = GameObject.FindGameObjectWithTag ("FukanCamera");
				if (Application.platform == RuntimePlatform.IPhonePlayer) {
					fukanCamera.SetActive (false);
				}
				Debug.Log ("fukanCamera");
			}
			if (WebUI3 == null) {
				if (GameObject.FindGameObjectWithTag ("Canvas") != null) {
					WebUI3 = GameObject.FindGameObjectWithTag ("Canvas");
					if (Application.platform == RuntimePlatform.IPhonePlayer) {
						WebUI3.SetActive (false);
					}
				}
				Debug.Log ("WebUI3");
			}



			if (pcCamera != null && iosCamera != null && photonView != null && player != null  && train != null && fukanCamera != null && WebUI3 != null) {
				Debug.Log ("dfasefelsfkelksj");
				SetState (State.Game);
			}


			break;
			// GameScene
		case State.Game:
			if (sceneStart) {
				sceneStart = false;
			}

			iosGameUpdate ();
			pcGameUpdate ();
			GameTrainUpdate ();

			break;
		case State.Rusult:
			if (sceneStart) {
				sceneStart = false;
			}
			break;
		default:
			break;

		}


	}

	public void SetPCCamera(GameObject obj){
		pcCamera = obj;

	}
	public void SetiosCamera(GameObject obj){
		iosCamera = obj;
	}
	public void SetTrain(GameObject obj){
		train = obj;
	}

	public void SetPlayer(GameObject obj){
		player = obj;
	}


	/*
	public IObservable<State> GameStateAsObservable(){
		return state.AsObservable ().Publish ().RefCount ();
	}
	*/
	void iosGameUpdate(){
		#if UNITY_IOS
		if (pcCamera && iosCamera && fukanCamera && WebUI3) {
			pcCamera.SetActive (false);
			iosCamera.SetActive (true);
			fukanCamera.SetActive (false);
			WebUI3.SetActive (false);
		}

		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				//photonView.RPC();
			}
		}
		#endif
	}


	void pcGameUpdate(){
		#if UNITY_IOS
		if (pcCamera && iosCamera && fukanCamera && WebUI3) {
			pcCamera.SetActive (true);
			iosCamera.SetActive (false);
			fukanCamera.SetActive (true);
			WebUI3.SetActive (true);
		}
		#endif
	}
	public void SetState(State next){
		state = next;
		sceneStart = true;
	}

	public State GetState(){
		return state;
	}
	void Spawn(int dir){

		GameObject that = PhotonNetwork.Instantiate (linePanels [dir + 1], currentCenterPositon + scale * Vector3.forward, Quaternion.Euler (new Vector3 (0, 0, 0)), 0)as GameObject;

		that.transform.RotateAround (currentCenterPositon, Vector3.up, currentAngle * 45);

		Transform waypoint = that.transform.FindChild ("Waypoint");
		waypoint.name += index.ToString ();
		waypoint.SetParent (WayPoints.transform);
		index++;

		currentCenterPositon = that.transform.position;

		//StartMove

		if (trainSplineMove.GetCanMove () == false) {
			trainSplineMove.StartMove ();
		}


	}

	void UpdateCurrentAngle(int num){
		currentAngle += num;
		if (currentAngle == 8)
			currentAngle = 0;
		else if (currentAngle == -1)
			currentAngle = 7;
	}

	void GameTrainUpdate(){
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Spawn((int)Direction.left);
			UpdateCurrentAngle (-1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			Spawn((int)Direction.straight);
			UpdateCurrentAngle (0);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			Spawn((int)Direction.right);
			UpdateCurrentAngle (1);
		}else if(Input.GetKeyDown(KeyCode.JoystickButton7)){
			Spawn((int)Direction.left);
			UpdateCurrentAngle (-1);
		} else if(Input.GetKeyDown(KeyCode.JoystickButton5)) {
			Spawn((int)Direction.straight);
			UpdateCurrentAngle (0);
		} else if(Input.GetKeyDown(KeyCode.JoystickButton8)) {
			Spawn((int)Direction.right);
			UpdateCurrentAngle (1);
		}
		#endif
	}

	void offCamera(){
		if (pcCamera) {
			pcCamera.SetActive (false);
		}
		if (iosCamera) {
			iosCamera.SetActive (false);
		}
	}
	public Vector3 GetStartPos(){
		return start_pos;
	}


	public void SetScene(string name){
		if (SceneManager.GetActiveScene ().name == "Title_scene") {
			if (name == "Main") {
				//NetworkManager.Instance.PlayerMake ();
				if (PhotonNetwork.connectionStateDetailed != PeerState.Joined) {
					return;
				}
				/*
				#if UNITY_IOS
				if (PhotonNetwork.countOfPlayersInRooms <= 1) {
					return;
				}

				#endif
				*/


				photonView.RPC ("RPCSetScene", PhotonTargets.Others, name);
			}
		}
		if (name == "Result_Failed") {
			photonView.RPC("RPCSetScene",PhotonTargets.Others,name);
			state = State.Start;
		}
		if (name == "Clear") {
			photonView.RPC("Clear",PhotonTargets.Others,name);
			state = State.Start;
		}
		if (name == "Title_scene") {
			photonView.RPC("Title_scene",PhotonTargets.Others,name);
			state = State.Start;
		}

		SceneManager.LoadScene (name);
	}
}