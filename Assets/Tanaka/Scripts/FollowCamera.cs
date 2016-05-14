using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

	public Transform player;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Player")!=null) {
			player = GameObject.FindGameObjectWithTag ("Player").transform;

		}
		offset = new Vector3 (0,1,-7);
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = Vector3.Lerp (transform.position, player.position+offset, Time.deltaTime);
		Debug.Log (transform.position);
		if (player != null) {
			transform.position = Vector3.Lerp (transform.position, player.position+offset, Time.deltaTime);
			Debug.Log (transform.position);
		} else {
			if (GameObject.FindGameObjectWithTag ("Player")!=null) {
				player = GameObject.FindGameObjectWithTag ("Player").transform;

			}

		}
	}

}
