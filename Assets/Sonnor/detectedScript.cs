using UnityEngine;
using System.Collections;

public class detectedScript : MonoBehaviour {

	public GameObject DetectableObject;

	GameObject SpawnedObject;

	// Use this for initialization
	void Start () {
		
	}

	void Awake () {

		SpawnedObject = (GameObject)Instantiate (DetectableObject, transform.position, Quaternion.identity);
		SpawnedObject.transform.parent = transform;
		SpawnedObject.gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider){

		Debug.Log ("Test");
		
		if (collider.name == "radar") {
			SpawnedObject.SetActive (true);
		}

	}

	void OnTriggerExit (Collider collider){
		
		if (collider.name == "radar") {
			SpawnedObject.SetActive (false);
		}

	}
}
