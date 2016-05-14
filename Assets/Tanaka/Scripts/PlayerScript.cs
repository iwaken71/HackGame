using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		//rb.velocity = Vector3.forward;
	
	}
	
	// Update is called once per frame
	void Update () {

		#if UNITY_IOS

		if (Input.GetMouseButtonDown (0)) {
			Jump();
		}

		#endif

		#if UNITY_EDITOR
		if (Input.GetKeyDown (KeyCode.Return)) {
			Jump ();
		}
		#endif

	
	}

	void FixedUpdate(){
		if (GameManager.Instance.GetState () == GameManager.State.Game) {
			Vector3 v = rb.velocity;
			rb.velocity = new Vector3 (0, v.y, 1);
		}


	}

	void Jump(){
		rb.AddForce (Vector3.up * 10, ForceMode.Impulse);
	}

}
