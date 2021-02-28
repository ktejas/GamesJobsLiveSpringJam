using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuNormal : MonoBehaviour
{
	private GameObject MMInverted = default;

    void Start()
    {
        MMInverted = GameObject.FindGameObjectWithTag("MMInverted");
        MMInverted.SetActive(false);
    }
    public void PlayButton()
	{
		// Load level 1
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void CameraNormalButton()
    {
        string[] sounds = new string[] { "SelectionA", "SelectionB", "SelectionC", "SelectionD", "SelectionE" };
        FindObjectOfType<AudioManager>().Play(sounds[Random.Range(0, 5)]);

        MMInverted.SetActive(true);

        gameObject.GetComponent<CameraManager>().setCameraInverted();

        this.gameObject.SetActive(false);
    }

	public void QuitButton()
    {
        FindObjectOfType<AudioManager>().Play("Quit");
        Application.Quit();
    }
}
