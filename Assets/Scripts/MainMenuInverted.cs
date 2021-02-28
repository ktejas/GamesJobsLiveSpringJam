using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInverted : MonoBehaviour
{
    private GameObject MMNormal = default;

    void Start()
    {
        MMNormal = GameObject.FindGameObjectWithTag("MMNormal");
    }

    public void PlayButton()
    {
        // Load level 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CameraInvertedButton()
    {
        MMNormal.SetActive(true);

        gameObject.GetComponent<CameraManager>().setCameraInverted();

        this.gameObject.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
