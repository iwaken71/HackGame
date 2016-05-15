using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TrainScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Goal") {
			SceneManager.LoadScene ("Clear");

		}

		if (col.tag == "Rock") {
			SceneManager.LoadScene ("Result_Failed");

		}

	}


}
