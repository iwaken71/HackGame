using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	private float speed = 5.0f;

	void Start(){
		Destroy (this.gameObject, 2.0f);
	}

	void Update () {
		this.transform.Translate (this.transform.forward * speed * Time.deltaTime, Space.World);
	}
}
