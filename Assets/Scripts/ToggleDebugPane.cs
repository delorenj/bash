using UnityEngine;
using System.Collections;

public class ToggleDebugPane : MonoBehaviour {

	private GameObject pane;

	public void Awake() {
		pane = GameObject.Find ("Debug Pane");
	}

	public void toggleDebugPane() {
		pane.SetActive (!pane.activeSelf);
	}

	public void Update() {
		if (Input.GetKeyDown ("right shift")) {
			toggleDebugPane();
		}
	}
}
