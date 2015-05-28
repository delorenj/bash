using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject camera = GameObject.Find ("Eye Ball");
		this.transform.parent = camera.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
