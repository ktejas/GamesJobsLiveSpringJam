using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject timer;
    private int timerTime = 60;

    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Timer");
        timer.GetComponent<Text>().text = TimeInFormat(timerTime);
        StartCoroutine(ChangeTime());
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
}
