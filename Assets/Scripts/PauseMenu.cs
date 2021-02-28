using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeButton()
    {
        FindObjectOfType<AudioManager>().Play("ResumeRestart");
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }

    public void RestartButton()
    {
        StartCoroutine(restart());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator restart()
    {
        FindObjectOfType<AudioManager>().Play("ResumeRestart");
        yield return new WaitForSeconds(0.5f);
        
    }

    public void QuitButton()
    {
        StartCoroutine(quit());
        Application.Quit();
    }

    IEnumerator quit()
    {
        FindObjectOfType<AudioManager>().Play("Quit");
        yield return new WaitForSeconds(0.5f);
        
    }
}
