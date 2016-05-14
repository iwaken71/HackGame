using UnityEngine;
using System.Collections;

public class AnimalAI : MonoBehaviour {


	Animation animation;

	private string MoveAnimation = "walk";
	public string AttackAnimation;
	public string FeededAnimation;

	public float fadeTime = 1;
	public float speed = 0.2f;

	public GameObject heartFx;

	Transform train;
	//public GameObject fadeFx;

	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Train")) {
			train = GameObject.FindGameObjectWithTag ("Train").transform;
		}
	}

	void Awake () {

		animation = GetComponent<Animation> ();

		animation.Play (MoveAnimation);

	}
	
	// Update is called once per frame
	void Update () {
		if (train == null) {
			if (GameObject.FindGameObjectWithTag ("Train")) {
				train = GameObject.FindGameObjectWithTag ("Train").transform;
			}
		}
		MoveTo ();
	
	}

	void OnTriggerEnter (Collider col) {
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
		if (train) {
			Vector3 direction = (train.position - transform.position).normalized;
			transform.position += direction * Time.deltaTime * speed;
			transform.LookAt (train.position);
		}
		//ここでプレーヤーを探す処理

	}

	void Destructor (){

		Destroy (this.gameObject);

	}
}
