using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform train;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Train")!=null) {
			train = GameObject.FindGameObjectWithTag ("Train").transform;
			this.transform.parent = train;
		}
		//offset = new Vector3 (0,1,-7);
	
	}

	// Update is called once per frame
	void LateUpdate () {
		if (train != null) {
			//transform.position = Vector3.Lerp (transform.position, train.position, Time.deltaTime);
		} else {
			if (GameObject.FindGameObjectWithTag ("Train")!=null) {
				train = GameObject.FindGameObjectWithTag ("Train").transform;
				this.transform.parent = train;
			}
		}
	}
}
