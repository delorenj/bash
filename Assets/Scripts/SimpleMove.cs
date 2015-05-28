using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
	
	float speed = 10.0f;

	// Update is called once per frame
	void Update () {
		var move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if (Input.GetKey ("left shift")) {
			move.y = move.z;
			move.z = 0;
		}

		transform.position += move * speed * Time.deltaTime;
	}
}
