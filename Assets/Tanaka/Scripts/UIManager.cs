using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : SingletonMonoBehaviour<UIManager> {

	public Text massage;
	PhotonView photonView;

	// Use this for initialization
	void Start () {
		photonView = GameObject.Find ("NetworkManager").GetComponent<PhotonView>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetMes(){
	}
}
