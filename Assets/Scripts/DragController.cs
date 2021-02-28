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

    public enum State {normal, dropped};
    public State state;
	 
	void Start()
	{
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gridSizeUnit = 2f;
		gridSize = new Vector3(gridSizeUnit, gridSizeUnit, gridSizeUnit); // Set x, y and z grid for all shapes

        state = State.normal;

    }

	public void Update()
	{
		// Rounding that position to the nearest grid spot
		var position = new Vector3(
			   Mathf.Clamp(Mathf.RoundToInt(this.transform.position.x / this.gridSize.x) * this.gridSize.x, 0, 6),
			   Mathf.Clamp(Mathf.RoundToInt(this.transform.position.y / this.gridSize.y) * this.gridSize.y, 0, 6),
			   Mathf.Clamp(Mathf.RoundToInt(this.transform.position.z / this.gridSize.z) * this.gridSize.z, 0, 6)
		   );

		// Applying the rounding to the nearest grid spot
		this.transform.position = position;

		//get with transform.eulerAngles.z
		transform.eulerAngles = new Vector3(0, direction, 0);
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
	}

	// Once the Player has finished moving the Object
	void OnMouseUp()
	{
		/* HANDLING BLOCK PLACEMENT: Y VALUE */
		/* Used to understand whether the block has been placed before - or are we placing on bottom (needed as
		   we dont use return statements) */
		bool[,,] array = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getOccupiedArray();

		// Get current position (Where is this position value taken?)
		int X = Mathf.FloorToInt(transform.position.x);
		int Y = Mathf.FloorToInt(transform.position.y); // To know where we're dropping from
		int Z = Mathf.FloorToInt(transform.position.z);

		// Getting width of shape
		int width = gameObject.GetComponent<ShapeSize>().getWidth();
		int height = gameObject.GetComponent<ShapeSize>().getHeight();

		// Getting all transforms of child elements (points used to interrogate array)
		Transform[] children = gameObject.GetComponentsInChildren<Transform>();

		// Returns the lowest Y level the shape should travel down to
		Y = findY(Y, width, children);

		// Moving shape to the Y level found above
		transform.position = new Vector3(X, Y + 2, Z);

		// Handling the occupied array updated by iterating over the child point objects
		for (int i = 0; i < width; i++)
		{
			// Set occupancy to true
			array[Mathf.RoundToInt(children[i].position.x), Mathf.RoundToInt(children[i].position.y), Mathf.RoundToInt(children[i].position.z)] = true;

			// If the container is of height 2, then set the above spaces to also be true
			if (height == 2)
            {
				array[Mathf.RoundToInt(children[i].position.x), Mathf.RoundToInt(children[i].position.y + 1), Mathf.RoundToInt(children[i].position.z)] = true;
			}
		}
		// Returning the modified array to the GameManager
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().setOccupiedArray(array);

		/* HANDLING STRENGTH VALUE */
		if (gameObject.transform.Find("TallMesh") == null)
		{
			// If the mesh isn't the tall mesh, then the height of the tower is 1
			gameManager.GetComponent<GameManager>().blockPlaced(gameObject.transform.position.y, 1f, gameObject.GetComponent<ShapeSize>().getSize());
		}
		else
		{
			// Height of tower is 2
			gameManager.GetComponent<GameManager>().blockPlaced(gameObject.transform.position.y, 2f, gameObject.GetComponent<ShapeSize>().getSize());
		}
		if(height == 1)
        {
			gameManager.GetComponent<GameManager>().UpdateY(transform.position.y);
		}
		else if (height == 2)
        {
			gameManager.GetComponent<GameManager>().UpdateY(transform.position.y + 1);
		}
		

        state = State.dropped;

    }

	int findY(int Y, int width, Transform[] children)
    {
		bool[,,] array = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().getOccupiedArray();

		// From the current height downwards
		for (int y = Y; y >= 0; y--)
		{
			for (int i = 0; i < width; i++) 
			{
				//Debug.Log(y);
				//Debug.Log(array[Mathf.RoundToInt(children[i].position.x), y, Mathf.RoundToInt(children[i].position.z)]);

				if (array[Mathf.RoundToInt(children[i].position.x), y, Mathf.RoundToInt(children[i].position.z)])
				{
					return y;
				}
			}
		}
		return 0;
	}

	void Rotate(){
		direction += 90;
	}


}
