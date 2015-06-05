using UnityEngine;
using System.Collections;

public class SimpleMove : MonoBehaviour {
	
	float speed = 10.0f;

	// Update is called once per frame
	void Update () {
		var move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		if (Input.GetKey ("left shift")) {
			Camera.main.orthographicSize += move.z * 0.01f * speed;
			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 3.5f, 11.5f);
			print ("orthosize" + Camera.main.orthographicSize);
		} else {
			transform.position += move * speed * Time.deltaTime;
		}


	}
}
