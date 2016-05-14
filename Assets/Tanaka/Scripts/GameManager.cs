using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>{

	GameObject pcCamera;
	GameObject iosCamera;
	PhotonView photonView;
	State state;
	ReactiveProperty<State> state = new ReactiveProperty<State>();

	enum State{
		Start=0,
		Game=1,
		Rusult=2
	}

	// Use this for initialization
	void Start () {
			pcCamera = GameObject.FindGameObjectWithTag ("MainCamera");
			iosCamera = GameObject.FindGameObjectWithTag ("iOSCamera");
			photonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView> ();


	}
	
	// Update is called once per frame
	void Update () {

		if (SceneManager.GetActiveScene ().name == "Main") {
			if (pcCamera && iosCamera) {
				#if UNITY_IOS

				pcCamera.SetActive (false);
				iosCamera.SetActive (true);

				#endif

				#if UNITY_EDITOR
				pcCamera.SetActive (true);
				iosCamera.SetActive (false);
				#endif
			}
			#if UNITY_IOS
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase == TouchPhase.Began) {
					//photonView.RPC();

				}
			}
			#endif
		}
	
	}

	public void SetPCCamera(GameObject obj){
		pcCamera = obj;

	}
	public void SetiosCamera(GameObject obj){
		iosCamera = obj;
	}
}
