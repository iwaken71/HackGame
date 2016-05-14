using UnityEngine;
using System.Collections;

public class MBTHelper : MonoBehaviour {
	
	public delegate void Trigger();
	public delegate void TouchPad(float x, float y);


	public const float tapDetectTime = 1.0f;

	public const float tapDetectLength = 15.0f;
	private const float tapDetectLengthSqrt = tapDetectLength*tapDetectLength;

	private Vector3 currentPos = Vector3.zero;
	private bool isScroll = false;
	private Vector3 tapPos = Vector3.zero;
	private float tapTime = 0.0f;
	private bool isTap = false;

	public static event Trigger OnTap;
	public static event TouchPad OnSwipe, OnScroll;

	public void Awake(){
		OnTap = delegate { };
		OnSwipe = delegate { };
		OnScroll = delegate { };
	}
	
	void Update () {
		if (Input.touchCount > 0) {
			if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
				isTap = true;
				isScroll = true;
				tapPos = Input.GetTouch(0).position;
				currentPos = Input.GetTouch(0).position;
			}
			switch (Input.GetTouch(0).phase) {
			case TouchPhase.Began:
			case TouchPhase.Moved:
				tapTime += Time.deltaTime;
				Vector3 vv = Input.GetTouch(0).position;
				Vector3 vp = currentPos - vv;
				if (isScroll && vp.sqrMagnitude > tapDetectLengthSqrt) {
					if (vp.x*vp.x > vp.y*vp.y){
						OnScroll(Input.mousePosition.x, 0);
						isTap = false;
					} else {
						OnSwipe(0, Input.mousePosition.y);
						isTap = false;
					}
				}
				currentPos = vv;
				break;
			case TouchPhase.Stationary:
				
			case TouchPhase.Ended:
				if (isScroll) {
					vp = currentPos - tapPos;
					if (tapTime < tapDetectTime){
						if (vp.sqrMagnitude < tapDetectLengthSqrt && isTap) {
							OnTap();
						}
					} else {
						if (vp.x*vp.x < vp.y*vp.y) {
							OnSwipe(0, Input.mousePosition.y);
						}
					}
				}
				isTap = false;
				isScroll = false;
				tapTime = 0.0f;
				break;
			}
		}
	}
}
	