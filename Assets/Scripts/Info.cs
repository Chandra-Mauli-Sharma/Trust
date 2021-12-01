using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public Text highScore;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text=PlayerPrefs.GetString("Score");
        highScore.text=PlayerPrefs.GetString("HighScore");
        PlayerPrefs.DeleteKey("Time");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
