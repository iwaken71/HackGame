using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public float speed = 3;
	Transform target;


	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Train").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (target) {
			Vector3 direction = (target.position - transform.position).normalized;
			transform.position += direction * speed * Time.deltaTime;
		} else {
			target = GameObject.FindGameObjectWithTag ("Train").transform;
		}
	}
}
