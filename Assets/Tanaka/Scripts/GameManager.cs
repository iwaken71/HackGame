using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UniRx;

public class GameManager : SingletonMonoBehaviour<GameManager>{

	GameObject pcCamera;
	GameObject iosCamera;
	PhotonView photonView;
	//ReactiveProperty<State> state = new ReactiveProperty<State>();
	State state;
	bool sceneStart = true;

	public enum State{
		Start=0,
		Game=1,
		Rusult=2
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
				sceneStart = false;
			}
			if (pcCamera == null) {
				pcCamera = GameObject.FindGameObjectWithTag ("MainCamera");
			}
			if (iosCamera == null) {
				iosCamera = GameObject.FindGameObjectWithTag ("iOSCamera");
			}
			if (photonView == null) {
				photonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView> ();
			}
			if (pcCamera != null && iosCamera != null && photonView != null) {
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
	/*
	public IObservable<State> GameStateAsObservable(){
		return state.AsObservable ().Publish ().RefCount ();
	}
	*/
	void iosGameUpdate(){
		#if UNITY_IOS
		if (pcCamera && iosCamera) {
			pcCamera.SetActive (false);
			iosCamera.SetActive (true);
		}
		if (Input.touchCount > 0) {
			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				//photonView.RPC();
			}
		}
		#endif
	}
	void pcGameUpdate(){
		#if UNITY_EDITOR
		if (pcCamera && iosCamera) {
			pcCamera.SetActive (true);
			iosCamera.SetActive (false);
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
}
