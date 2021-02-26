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


	void Start()
	{
		highestY = 0;
		timer = GameObject.FindGameObjectWithTag("Timer");
		strengthCounter = GameObject.FindGameObjectWithTag("strengthCounter");
		timer.GetComponent<Text>().text = TimeInFormat(timerTime);
		StartCoroutine(ChangeTime());
		plane = new Plane(Vector3.up, new Vector3(0, yOffsetForDraggedObject, 0));
	}

	void Update()
	{
		displayStrength(); // todo: call less frequently? Doesn't need to be called every frame

        if (Input.GetKeyDown(KeyCode.Space))
        {
			// Used for resetting the game, useful for development buils - will need configuring as we make a start/pause menu
			//SceneManager.LoadScene(SceneManager.GetActiveScene().name);

			paused = togglePause();
		}

		yOffsetForDraggedObject = highestY + 4;
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
		else
		{
			Debug.Log("Game Over!");
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
		Debug.Log(yHeight);
	}

	public void increaseCollisionCount (int count)
	{
		collisionCount += count;
	}
	public void UpdateY(float newY){
		print("y updated");
		if (newY > highestY){
			highestY = newY;
			plane = new Plane(Vector3.up, new Vector3(0, yOffsetForDraggedObject, 0));
		}
		
	}

}
