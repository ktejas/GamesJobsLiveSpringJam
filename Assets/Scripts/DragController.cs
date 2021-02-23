using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
	private Vector3 mOffset;
	private float mZCoord;
	private Vector3 gridSize = new Vector3(1,1,1); // Set x, y and z grid for all shapes

	public void Update()
	{
		// Rounding that position to the nearest grid spot
		var position = new Vector3(
			   Mathf.RoundToInt(this.transform.position.x / this.gridSize.x) * this.gridSize.x,
			   Mathf.RoundToInt(this.transform.position.y / this.gridSize.y) * this.gridSize.y,
			   Mathf.RoundToInt(this.transform.position.z / this.gridSize.z) * this.gridSize.z
		   );

		// Applying the rounding to the nearest grid spot
		this.transform.position = position;

		//get with transform.eulerAngles.z
		transform.eulerAngles = new Vector3(0, 0, 0);
	}

	void OnMouseDown()
	{
		mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

		// Store offset = gameobject world pos - mouse world pos
		mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
	}

	private Vector3 GetMouseAsWorldPoint()
	{
		// Pixel coordinates of mouse (x,y)
		Vector3 mousePoint = Input.mousePosition;

		// z coordinate of game object on screen
		mousePoint.z = mZCoord;

		// Convert it to world points
		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	void OnMouseDrag()
	{
		// Moving shape with the cursor
		transform.position = GetMouseAsWorldPoint() + mOffset;
	}
}
