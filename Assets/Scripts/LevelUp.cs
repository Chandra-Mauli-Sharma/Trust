using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    public GameObject panel;
    public Slider slider;

    void OnTriggerEnter(Collider others)
    {
        StartCoroutine(LoadAsynchronously ());
    }

    IEnumerator LoadAsynchronously ()
    {
        panel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);

        while(!operation.isDone)
        {
            float pro=Mathf.Clamp01(operation.progress/.9f);
            slider.value=pro;
            yield return null;
        }
    }
}
