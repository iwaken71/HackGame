using UnityEngine;
using System.Collections;

public class iOSCamera : MonoBehaviour {

	Transform target;

	// Use this for initialization
	void Start () {
		
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (target == null) {
			if (GameObject.FindGameObjectWithTag ("Player") != null) {
				target = GameObject.FindGameObjectWithTag ("Player").transform;
			}
		}
		if (target != null) {
			transform.position = target.position + new Vector3 (0,1,0);
			//transform.LookAt (target);
		}
	
	}
}
