using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//Rigidbody rb;
	GameObject train;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();

		//rb.velocity = Vector3.forward;

	
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position += new Vector3 (0, transform.position.y, 1) * Time.deltaTime;
			


		#if UNITY_IOS

		if (Input.GetMouseButtonDown (0)) {
			Jump();
		}
		if (train == null) {
			if (GameObject.FindGameObjectWithTag ("Train")) {
				train = GameObject.FindGameObjectWithTag ("Train");
				transform.position = train.transform.position + new Vector3(0,1,0);
				this.transform.parent = train.transform;
			}
		}

		#endif

		#if UNITY_EDITOR
		if (Input.GetKeyDown (KeyCode.Return)) {
			Jump ();
		}
		if (train == null) {
			if (GameObject.FindGameObjectWithTag ("Train")) {
				train = GameObject.FindGameObjectWithTag ("Train");
				transform.position = train.transform.position + new Vector3(0,1,0);
				this.transform.parent = train.transform;
			}
		} else {
			//transform.position = train.transform.position + new Vector3(0,1,0);
		}

		#endif

	
	}

	void FixedUpdate(){
		/*
		if (GameManager.Instance.GetState () == GameManager.State.Game) {
			Vector3 v = rb.velocity;
			rb.velocity = new Vector3 (0, v.y, 1);
		}
*/


	}

	void Jump(){
		//rb.AddForce (Vector3.up * 10, ForceMode.Impulse);
	}

}
