using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform player;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Train")!=null) {
			player = GameObject.FindGameObjectWithTag ("Train").transform;

		}
		offset = new Vector3 (0,1,-7);
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (player != null) {
			transform.position = Vector3.Lerp (transform.position, player.position+offset, Time.deltaTime);
		} else {
			if (GameObject.FindGameObjectWithTag ("Train")!=null) {
				player = GameObject.FindGameObjectWithTag ("Train").transform;
			}
		}
	}

}
