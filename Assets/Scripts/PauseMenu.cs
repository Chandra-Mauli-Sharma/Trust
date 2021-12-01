using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject option;

    public Keyboard keyboard;

    private bool paused;
    // Start is called before the first frame update
    void Start()
    {
        keyboard=Keyboard.current;

    }

    // Update is called once per frame
    void Update()
    {
        if(keyboard!=null){
            if(keyboard.escapeKey.wasPressedThisFrame){
                Option();
            }

        }
        if(paused)
        {
            Time.timeScale=0f;
        }
        else{
            Time.timeScale=1f;
        }
    }
    
    public void Option()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        option.SetActive(true);
        paused=true;
    }
    public void Back()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        option.SetActive(false);
        paused=false;
    }
}
