using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {


	public float fadeTime = 1;

	// Use this for initialization
	void Start () {
	
	}

	void Awake () {

		Invoke ("Destructor", fadeTime); 

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Destructor (){

		Destroy (this);

	}

}
