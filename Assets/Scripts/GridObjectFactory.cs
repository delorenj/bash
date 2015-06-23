using UnityEngine;
using System.Collections;

public class GridObjectFactory : MonoBehaviour {
	public GameObject testCube;

	public void createTestCube() {
		GameObject go = (GameObject) Instantiate (testCube, Input.mousePosition, testCube.transform.rotation);
		GridObject cube = go.GetComponent<GridObject> ();
		cube.SetMoving ();
	}
}
