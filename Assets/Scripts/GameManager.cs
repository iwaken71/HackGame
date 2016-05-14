using UnityEngine;
using System.Collections;

public class GameManager : SingletonMonoBehaviour<GameManager>{

	GameObject pcCamera;
	GameObject iosCamera;

	// Use this for initialization
	void Start () {
		pcCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		iosCamera =  GameObject.FindGameObjectWithTag ("iOSCamera");

	}
	
	// Update is called once per frame
	void Update () {
		
		if (pcCamera && iosCamera) {
			#if UNITY_IOS

			pcCamera.SetActive(false);
			iosCamera.SetActive(true);

			#endif

			#if UNITY_EDITOR
			pcCamera.SetActive(true);
			iosCamera.SetActive(false);
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
