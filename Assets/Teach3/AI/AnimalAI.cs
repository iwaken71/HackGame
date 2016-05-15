using UnityEngine;
using System.Collections;

public class AnimalAI : MonoBehaviour {


	Animation animation;

	public string MoveAnimation;
	public string AttackAnimation;
	public string FeededAnimation;

	public float fadeTime = 1;
	public float speed = 3;

	public GameObject heartFx;
	Transform target;
	//public GameObject fadeFx;

	// Use this for initialization
	void Start () {
		animation.Play (MoveAnimation);

	}

	void Awake () {

		animation = GetComponent<Animation> ();



	}
	
	// Update is called once per frame
	void Update () {
		if (target == null) {
			if (GameObject.FindGameObjectWithTag ("Train")) {
				target = GameObject.FindGameObjectWithTag ("Train").transform;
			}

		}

		MoveTo ();
	
	}

	void OnTriggerEnter (Collider col ) {
		Debug.Log (col.name);

		if (col.transform.tag == "PlayerSpace") {

			AttackPlayer ();

		} else if (col.transform.tag == "food") {

			FadeOut ();

		}

	}

	void AttackPlayer(){

		animation.Play (AttackAnimation);

		// ここでライフを減らす処理など書く

		//Instantiate (FadeParticle);
		Invoke ("Destructor", fadeTime);


	}

	void FadeOut (){

		animation.Play(FeededAnimation);

		// ここでスコアを足す処理など書く

		Instantiate (heartFx, this.transform.position + Vector3.up, Quaternion.Euler(270.0f, 0, 0));

		Invoke ("Destructor", fadeTime);

	}

	void MoveTo (){

		Vector3 direction = (target.position - transform.position).normalized;

		transform.position += direction * speed * Time.deltaTime;
		transform.LookAt (target.position);

		//ここでプレーヤーを探す処理

	}

	void Destructor (){

		Destroy (this.gameObject);

	}
}
