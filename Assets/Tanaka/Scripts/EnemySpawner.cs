using UnityEngine;
using System.Collections;

public class EnemySpawner :MonoBehaviour {

	public string enemyName;
	int count = 0;

	// Use this for initialization
	void Start () {
		count = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		//if (count < 1) {
			if (col.tag == "Train") {
				Spawn ();
			}
		//}

	}

	void Spawn(){
		//#if UNITY_IOS
		Debug.Log("sadfasd");
		PhotonNetwork.Instantiate (enemyName,transform.position,transform.rotation,0);
		count++;
		//#endif
	}
}
