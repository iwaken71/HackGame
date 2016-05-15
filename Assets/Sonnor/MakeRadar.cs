using UnityEngine;
using System.Collections;

public class MakeRadar : MonoBehaviour {

	public float scale = 10;

	public float speed = 360;

	GameObject Detector;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {
		Detector = GameObject.CreatePrimitive (PrimitiveType.Cube);
		Detector.transform.name = "radar";
		Detector.GetComponent<MeshRenderer> ().enabled = false;
		Detector.GetComponent<BoxCollider> ().isTrigger = true;
		Detector.transform.localScale = new Vector3(scale, 100, scale);
		Vector3 deltaInitPosition = new Vector3 (scale / 2, 0, scale / 2);
		Detector.transform.position = this.gameObject.transform.position + deltaInitPosition;
		Detector.transform.parent = this.transform;
		Detector.AddComponent<Rigidbody> ().useGravity = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		Detector.transform.RotateAround (this.gameObject.transform.position, Vector3.up, speed *Time.fixedDeltaTime);

	}
}
