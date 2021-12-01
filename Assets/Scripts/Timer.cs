using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeConsumed = 0;
    public bool timerIsRunning = false;
    public Text timeText;
    public string score;


    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        timeText.text=PlayerPrefs.GetString("Score","00:00");
        score=PlayerPrefs.GetString("HighScore","00:00");
        timeConsumed=PlayerPrefs.GetFloat("Time",0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            timeConsumed+=Time.deltaTime;
            DisplayTime(timeConsumed);
            PlayerPrefs.SetFloat("Time",timeConsumed);
        }
        else{
            score=timeText.text;
            PlayerPrefs.SetString("HighScore",score);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        PlayerPrefs.SetString("Score",timeText.text);
        if((PlayerPrefs.GetString("Score").CompareTo(PlayerPrefs.GetString("HighScore")))<0)
            PlayerPrefs.SetString("HighScore",timeText.text);
    }

    void setTimer()
    {
        timerIsRunning=!timerIsRunning;
    }
}
