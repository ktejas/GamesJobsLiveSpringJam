using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour
{
	private Vector3 mOffset;
	private float mZCoord;
    private float gridSizeUnit;
	private Vector3 gridSize; 
	private GameObject gameManager = default;
	float direction = 0;
     
    void Start()
    {
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gridSizeUnit = 1.1f;
        gridSize = new Vector3(gridSizeUnit, gridSizeUnit, gridSizeUnit); // Set x, y and z grid for all shapes
    }

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
		transform.eulerAngles = new Vector3(0, direction, 0);

		
		// Prevention from going below y = 0
		/*
		if(gameObject.transform.position.y < -1)
        {
			gameObject.transform.position = new Vector3(8, 4, 6); // might need to update this value, as model of the grid + environment comes in
        }
		*/
	}

	//void OnMouseDown()
	//{
		//mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

		// Store offset = gameobject world pos - mouse world pos
		//mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
	//}

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
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (gameManager.GetComponent<GameManager>().plane.Raycast(ray, out gameManager.GetComponent<GameManager>().distance))
        {
             transform.position = ray.GetPoint(gameManager.GetComponent<GameManager>().distance);
        }

		//rotates currently held box
		if (Input.GetMouseButtonDown(1) || Input.GetKeyDown("r")){
			 Rotate();
		}
		// Moving shape with the cursor
		//transform.position = GetMouseAsWorldPoint() + mOffset;
	}

	// Once the Player has finished moving the Object
    void OnMouseUp()
    {
		if(gameObject.transform.Find("TallMesh") == null)
        {
			// If the mesh isn't the tall mesh, then the height of the tower is 1
			gameManager.GetComponent<GameManager>().blockPlaced(gameObject.transform.position.y, 1f, gameObject.GetComponent<ShapeSize>().getSize());
        }
        else
        {
			// Height of tower is 2
			gameManager.GetComponent<GameManager>().blockPlaced(gameObject.transform.position.y, 2f, gameObject.GetComponent<ShapeSize>().getSize());
		}
	}

	void Rotate(){
		direction += 90;
	}


}
