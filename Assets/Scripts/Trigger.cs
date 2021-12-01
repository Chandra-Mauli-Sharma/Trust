using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject message;

    // Start is called before the first frame update
    void Start()
    {
        
    }

      void OnTriggerEnter(Collider others)
      {
          message.SetActive(true);
      }
}
