using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public Slider slider;

    public void PlayGame ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        StartCoroutine(LoadAsynchronously ());
    }

    IEnumerator LoadAsynchronously ()
    {
        panel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("Level1");

        while(!operation.isDone)
        {
            float pro=Mathf.Clamp01(operation.progress/.9f);
            slider.value=pro;
            yield return null;
        }
    }

        public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
