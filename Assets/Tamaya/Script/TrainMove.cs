using UnityEngine;
using System.Collections;

public class TrainMove : MonoBehaviour {

	int CurrentIndex = 0;

	Vector3 FromPoint;
	Vector3 MiddlePoint;
	Vector3 ToPoint;

	float startTime;

	public float throughTime = 6;

	GameObject WayPoints;


	// Use this for initialization
	void Start () {
		WayPoints = GameObject.FindGameObjectWithTag ("WayPoints");
	}

	void Awake (){

		startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if (GameManager.Instance.GetState () == GameManager.State.Game) {

			float deltaTime = Time.time - startTime;

			if (deltaTime <= throughTime / 2) {
				transform.position = Vector3.Lerp (FromPoint, MiddlePoint, deltaTime / (throughTime / 2));
				transform.LookAt (MiddlePoint);
			} else if (deltaTime <= throughTime) {
				transform.position = Vector3.Lerp (MiddlePoint, ToPoint, (deltaTime - throughTime / 2) / (throughTime / 2));
				transform.LookAt (ToPoint);
			} else {
				UpdateDirections ();
			}
		}

	}

	void UpdateDirections(){

		if (CurrentIndex + 2 < WayPoints.transform.childCount) {
			startTime = Time.time;
			CurrentIndex++;
			FromPoint = ToPoint;
			MiddlePoint = FromPoint + WayPoints.transform.GetChild (CurrentIndex).forward * instantiateLinePanel.scale / 2;
			ToPoint = WayPoints.transform.GetChild (CurrentIndex + 1).position;
		}
	}



}
