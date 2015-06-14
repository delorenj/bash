using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour {
	// The underlying game object that is to be placed on the grid
	public GameObject gameObject;

	// How many grid units this object consumes in the X dimension
	public int unitSpanX = 1;

	// How many grid units this object consumes in the Y dimension
	public int unitSpanY = 1;

	private Vector3 currentGridSquare;

	// The grid object's current state
	private string state;

	// Nested class that contains all possible states for this grid object
	public class GridObjectState
	{
		public const string constructing = "Constructing";
		public const string active = "Active";
		public const string inactive = "Inactive";
		public const string moving = "Moving";
	}

	public void Awake() {
		this.state = GridObjectState.active;
	}

	public void Update() {
		Vector3 placePoint = GetGridSquareAnchorPoint (Input.mousePosition);

		if (placePoint != Vector3.zero) {
			if(state == GridObjectState.moving) {
				gameObject.transform.position = placePoint;
			}
		}
	}

	Vector3 GetGridSquareAnchorPoint (Vector3 mousePosition)
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
//			ToggleDebugPane dp = GameObject.FindGameObjectWithTag("DebugPane").GetComponent<ToggleDebugPane>();
//			if (dp.active) {
				Debug.DrawLine (ray.origin, hit.point);
				Debug.Log ("Hit Point: " + hit.point);
//			}
			return hit.point;
		} else {
			return Vector3.zero;
		}
	}

	public void createObject() {
		Vector3 createPoint = Input.mousePosition;
		Debug.Log ("Clicked: " + createPoint);
		Instantiate (this.gameObject, createPoint, Quaternion.identity);
		state = GridObjectState.moving;
	}

}

