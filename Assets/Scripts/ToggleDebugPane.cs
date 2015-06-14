using UnityEngine;
using System.Collections;

public class ToggleDebugPane : MonoBehaviour {

	private GameObject pane;
	public bool active = false;

	public void Awake() {
		pane = GameObject.Find ("Debug Pane");
		pane.SetActive (active);
	}

	public void toggleDebugPane() {
		active = !pane.activeSelf;
		pane.SetActive (!pane.activeSelf);

	}

	public void Update() {
		if (Input.GetKeyDown ("right shift")) {
			toggleDebugPane();
		}
	}
}
