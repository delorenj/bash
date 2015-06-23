using UnityEngine;
using System.Collections;

public class GridObject : MonoBehaviour {
	// The underlying game object that is to be placed on the grid

	// How many grid units this object consumes in the X dimension
	public int unitSpanX;

	// How many grid units this object consumes in the Y dimension
	public int unitSpanY;
		
	private float offset = 2.0f;
	private float gridSize = 2.0f;

	private Vector3 currentGridSquare;

	// The grid object's current state
	private string state;

	private ToggleDebugPane dp;

	// Nested class that contains all possible states for this grid object
	public class GridObjectState
	{
		public const string constructing = "Constructing";
		public const string active = "Active";
		public const string inactive = "Inactive";
		public const string moving = "Moving";
	}

	public void Awake() {
		dp = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ToggleDebugPane> ();
		this.state = GridObjectState.active;
	}

	public void Update() {
		Vector3 placePoint = GetGridSquareAnchorPoint (Input.mousePosition);

		if (placePoint != Vector3.zero) {
			if(state == GridObjectState.moving) {
				transform.position = placePoint;
			}
		}
	}

	public void setState(string state) {
		this.state = state;
	}

	public void SetMoving ()
	{
		GameObject[] gos = GameObject.FindGameObjectsWithTag ("GridObject");
		foreach (GameObject go in gos) {
			GridObject obj = go.GetComponent<GridObject>();
			obj.setState(GridObject.GridObjectState.inactive);
		}
		this.setState (GridObject.GridObjectState.moving);
	}

	Vector3 GetGridSquareAnchorPoint (Vector3 mousePosition)
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) {
			if (dp.active) {
				Debug.DrawLine (ray.origin, hit.point);
				Debug.Log ("Hit Point: " + hit.point);
			}
			Vector3 V = hit.point;
			V -= Vector3.one * offset;
			V /= gridSize;
			V = new Vector3(Mathf.Round(V.x), Mathf.Round(V.y), Mathf.Round(V.z));
			V *= gridSize;
			V += Vector3.one * offset;
			//return new Vector3(Mathf.Round(hit.point.x), Mathf.Round (hit.point.y), Mathf.Round (hit.point.z)) * unitSpanX;
			return V;
		} else {
			return Vector3.zero;
		}
	}
}

