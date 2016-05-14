using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour {

	public Text text;
	public float i;

	void Update () {
		text.text = "a";
		if (Input.touchCount > 0) {
			i += Time.deltaTime;
			if (Input.touchCount == 1) {
				text.text = i.ToString ();
			}
		} else {
			i = 0;
		}
			
	}
}
