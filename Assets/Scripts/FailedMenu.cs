using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailedMenu : MonoBehaviour
{
    public void RetryButton()
    {
        // Retry current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}
