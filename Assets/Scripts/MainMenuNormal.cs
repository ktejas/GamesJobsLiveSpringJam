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
        MMInverted.SetActive(true);

        gameObject.GetComponent<CameraManager>().setCameraInverted();

        this.gameObject.SetActive(false);
    }

	public void QuitButton()
    {
		Application.Quit();
    }
}
