using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class GameManager : MonoBehaviour
{
    public GameObject panel;
    public Slider slider;

    public GameObject restartOption;
    public Keyboard keyboard;
    public void RestartOption()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        restartOption.SetActive(true);
    }

    public void Restart()
    {
        StartCoroutine(LoadAsynchronously ());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        keyboard=Keyboard.current;
        if(keyboard!=null)
{        if(keyboard.yKey.wasPressedThisFrame){
            Restart();
        }
        if(keyboard.nKey.wasPressedThisFrame){
            MainMenu();
        }}

        if(keyboard.mKey.wasPressedThisFrame){
            if(!(Cursor.visible))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }else{
                            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            }

        }
    }

    IEnumerator LoadAsynchronously ()
    {
        panel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);

        while(!operation.isDone)
        {
            float pro=Mathf.Clamp01(operation.progress/.9f);
            slider.value=pro;
            yield return null;
        }
    }

    public void MainMenu()
    {
        StartCoroutine(LoadAsynchronously2 ());
    }

    IEnumerator LoadAsynchronously2 ()
    {
       panel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("MainMenu");

        while(!operation.isDone)
        {
            float pro=Mathf.Clamp01(operation.progress/.9f);
            slider.value=pro;
            yield return null;
        }
    }
}
