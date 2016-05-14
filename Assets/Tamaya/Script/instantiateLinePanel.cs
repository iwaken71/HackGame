using UnityEngine;
using System.Collections;

public class instantiateLinePanel : MonoBehaviour {

	static int index = 2;

	GameObject WayPoints;

	public string[] linePanels = new string[3];
	int currentAngle = 0; //0 to 7
	public Vector3 currentCenterPositon;
	public static float scale =1; 

	enum Direction {
		right=-1,
		straight,
		left
	}

	// Use this for initialization
	void Start () {
		WayPoints = GameObject.FindGameObjectWithTag ("WayPoints");
	
	}

	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			Spawn((int)Direction.left);
			UpdateCurrentAngle (-1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)) {
			Spawn((int)Direction.straight);
			UpdateCurrentAngle (0);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)) {
			Spawn((int)Direction.right);
			UpdateCurrentAngle (1);
		}
		#endif

	}

	void Spawn(int dir){
		
		GameObject that = PhotonNetwork.Instantiate (linePanels[dir+1], currentCenterPositon + scale*Vector3.forward, Quaternion.Euler(new Vector3(0,0,0)),0)as GameObject;

		that.transform.RotateAround(currentCenterPositon, Vector3.up, currentAngle * 45 );

		Transform waypoint = that.transform.FindChild ("Waypoint");
		waypoint.name += index.ToString ();
		waypoint.SetParent (WayPoints.transform);
		index++;

		currentCenterPositon = that.transform.position;
			

	}

	void UpdateCurrentAngle(int num){
		currentAngle += num;
		if (currentAngle == 8)
			currentAngle = 0;
		else if (currentAngle == -1)
			currentAngle = 7;
	}
}
