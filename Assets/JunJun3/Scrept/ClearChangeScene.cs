using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClearChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.JoystickButton17)) {
			GameManager.Instance.SetScene ("Title_scene");
			//SceneManager.LoadScene ("Title_scene");
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameManager.Instance.SetScene ("Title_scene");
		}
	
	}
}
