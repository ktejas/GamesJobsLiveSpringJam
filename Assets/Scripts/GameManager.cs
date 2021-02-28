using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private GameObject timer;
	private GameObject strengthCounter;
	private int timerTime = 60;
	private int currentStrength = 100;
	private float yHeight = 0; // Initialised to zero, used for knowing the current height of the tower
	[SerializeField] public GameObject shapes = default;
	private int spaceOccupied = 0; // The amount of space occupied on the grid starts at 0
	private int collisionCount = 0;
	public float yOffsetForDraggedObject = 1;
	public Plane plane;
	public float distance;
	public float highestY;

	bool paused = false; // is the game paused
	private GameObject failedMenu = default;
	private GameObject[] starsMenu = default;

	// Defining the occupied array, used to know what places are already occupied
	public const int GRID_WIDTH = 15;
	public const int GRID_HEIGHT = 15;
	public const int TOP_HEIGHT = 15;

	private bool[,,] occupied = new bool[GRID_WIDTH, GRID_HEIGHT, TOP_HEIGHT];

	public bool[,,] getOccupiedArray() 
	{
		return occupied;
	}
	public void setOccupiedArray(bool[,,] newArray)
	{
		occupied = newArray;
	}

	void Start()
	{
		highestY = 0;
		yOffsetForDraggedObject = highestY + 3;
		timer = GameObject.FindGameObjectWithTag("Timer");
		strengthCounter = GameObject.FindGameObjectWithTag("strengthCounter");
		timer.GetComponent<Text>().text = TimeInFormat(timerTime);
		StartCoroutine(ChangeTime());
		plane = new Plane(Vector3.up, new Vector3(0, yOffsetForDraggedObject, 0));

		// Splash screen management
		failedMenu = GameObject.FindGameObjectWithTag("FailedMenu");
		failedMenu.SetActive(false);


		starsMenu = GameObject.FindGameObjectsWithTag("StarsMenu");
		for(int i=0; i<starsMenu.Length; i++)
        {
			starsMenu[i].SetActive(false);
		}

		for(int i=0; i<15; i++)
        {
			for(int j=0; j<15; j++)
            {
				for(int l=0; l<15; l++)
                {
					occupied[i, j, l] = false;
                }
            }
        }
	}



	void Update()
	{ 
		displayStrength(); // todo: call less frequently? Doesn't need to be called every frame

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// Used for resetting the game, useful for development buils - will need configuring as we make a start/pause menu
			paused = togglePause();
		}

		yOffsetForDraggedObject = highestY + 6;

		// If they've hit the target height and time is up
		if (ScoreManager() && timerTime <= 0)
		{
			showStars();
		}

		// If they havent hit the target height and time is up
		if (!ScoreManager() && timerTime <= 0)
		{
			failedMenu.SetActive(true);
		}

		// If the current strength falls <= 0, then fail
		if (currentStrength <= 0)
        {
			failedMenu.SetActive(true);
        }
	}
	
	bool ScoreManager()
	{
		if(SceneManager.GetActiveScene().buildIndex == 1)
		{
			// Currently handling first level
			if(yHeight >= 15) // target height is above 15
			{
				return true;
			}
		}
		if (SceneManager.GetActiveScene().buildIndex == 2)
		{
			// Currently handling second level
			if (yHeight >= 30) // target height is above 30
			{
				return true;
			}
		}
		if (SceneManager.GetActiveScene().buildIndex == 3)
		{
			// Currently handling second level
			if (yHeight >= 30) // target height is above 30
			{
				return true;
			}
		}
		return false;
	}

	void showStars()
    {
		if (currentStrength < 25 )
		{
			// no stars
			starsMenu[0].SetActive(true);
			Debug.Log("we're at zero");
		}
		if (currentStrength >=25 && currentStrength < 50)
		{
			// no stars
			starsMenu[1].SetActive(true);
		}
		if (currentStrength >= 50 && currentStrength < 75)
		{
			// no stars
			starsMenu[2].SetActive(true);
		}
		if (currentStrength >= 75 && currentStrength < 100)
		{
			// no stars
			starsMenu[3].SetActive(true);
		}
	}

	void OnGUI()
	{
		if (paused)
		{
			GUILayout.Label("Game is paused!");
			if (GUILayout.Button("Click to unpause!"))
			{
				paused = togglePause();
			}
			if (GUILayout.Button("Restart the game"))
			{
				paused = togglePause(); //restarting time
				SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			}

		}
	}

	bool togglePause()
	{
		if (Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return (false);
		}
		else
		{
			Time.timeScale = 0f;
			return (true);
		}
	}

	IEnumerator ChangeTime()
	{
		yield return new WaitForSeconds(1.0f);
		if (timerTime > 0)
		{
			timerTime--;
		}
		timer.GetComponent<Text>().text = TimeInFormat(timerTime);
		StartCoroutine(ChangeTime());
	}

	String TimeInFormat(int time)
	{
		int minutes = 0;
		int seconds = 0;

		minutes = time / 60;
		seconds = time % 60;

		if(minutes < 10 && seconds < 10)
			return "0" + minutes + ":0" + seconds;
		else if (minutes > 10 && seconds < 10)
			return minutes + ":0" + seconds;
		else if (minutes < 10 && seconds > 10)
			return "0" + minutes + ":" + seconds;
		else
			return minutes + ":" + seconds;
	}

	/*
	 * Tower strength work
	 */

	public void blockPlaced(float yPlacement, float heightOfObject, int size)
	{
		if(yPlacement + heightOfObject > yHeight)
		{
			yHeight = yPlacement + heightOfObject;
		}
		spaceOccupied += size;
	}

	void displayStrength()
	{
		if (spaceOccupied != 0) // avoiding divide by-zero error
		{
			strengthCounter.GetComponent<Text>().text = (100 - ((yHeight * 9) / spaceOccupied) - (collisionCount * 3)).ToString();
		}
		else
		{
			strengthCounter.GetComponent<Text>().text = 0.ToString();
		}
	}

	public void increaseCollisionCount (int count)
	{
		collisionCount += count;
	}
	public void UpdateY(float newY){
		//print("y updated");
		if (newY > highestY){
			highestY = newY;
			plane = new Plane(Vector3.up, new Vector3(0, yOffsetForDraggedObject, 0));
		}
		
	}

}
