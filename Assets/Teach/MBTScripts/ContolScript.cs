using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContolScript : MonoBehaviour {

	public Text DebugText;
	public bool DebugMode = false;

	public GameObject hako;
	public GameObject maru;

	// Use this for initialization
	void Start () {
		MBTHelper.OnTap += () => {
			Debug.Log ("::Tap::");
			ShowParameter("::Tap::");
			MBTOnTap ();
		};
		MBTHelper.OnSwipe += (x, y) => {
			Debug.Log ("::Swipe " + x.ToString() + ", " + y.ToString() + "::");
			ShowParameter("::Swipe " + x.ToString() + ", " + y.ToString() + "::");
			MBTOnSwipe (x/Screen.width, y/Screen.height);
		};
		MBTHelper.OnScroll += (x, y) => {
			Debug.Log ("::Scroll " + x.ToString() + ", " + y.ToString() + "::");
			ShowParameter("::Scroll " + x.ToString() + ", " + y.ToString() + "::");
			MBTOnScroll (x/Screen.width, y/Screen.height);
		};

		DebugText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (Input.mousePosition.x);
	}

	private void MBTOnTap () {

	}

	private void MBTOnSwipe (float xx, float yy) {
		hako.transform.Translate (xx, yy, 0);
	}

	private void MBTOnScroll (float xx, float yy) {
		maru.transform.Translate (xx, yy, 0);

	}

	private void ShowParameter (string st) {
		if (DebugMode) {
			DebugText.text = st;
		}
	}
}
