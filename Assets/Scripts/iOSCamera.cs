using UnityEngine;
using System.Collections;

public class iOSCamera : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				target = GameObject.FindGameObjectWithTag ("Player").transform;
			}
		}
		if (target != null) {
			transform.LookAt (target);
		}
	
	}
}
