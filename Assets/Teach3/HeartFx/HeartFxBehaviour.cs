using UnityEngine;
using System.Collections;

public class HeartFxBehaviour : MonoBehaviour {

	private ParticleSystem particle;
	private float timer = 2.0f;

	void Start () {
		particle = this.GetComponent<ParticleSystem> ();
	}

	void Update(){
		timer -= Time.deltaTime;
		if (timer < 0) {
			particle.Stop ();
			Destroy (this.gameObject, 5.0f);
		}
	}

}
