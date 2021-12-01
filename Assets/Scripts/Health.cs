using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private GameObject gameManager;
    public float health;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        health=100.0f;
        gameManager=GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if(health>0)
        {
            slider.value=health;
        }
        else
        {
            gameManager.GetComponent<GameManager>().RestartOption();
        }
    }

     void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(health>0)
        {
            if(hit.collider.tag == "Rock")
            {
                health=health-1.0f;
            }
            if(hit.collider.tag=="Lava")
            {
                health=0;
            }
        }
    }
}
