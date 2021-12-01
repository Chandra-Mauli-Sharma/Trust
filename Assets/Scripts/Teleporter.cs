using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
      private GameObject[] targets;
      public GameObject player;
     
      void OnTriggerEnter(Collider others)
      {
         CharacterController cc = player.GetComponent<CharacterController>();
 
         cc.enabled = false;
        player.transform.position=targets[Mathf.FloorToInt((Random.value)*targets.Length)].transform.position;
         cc.enabled = true;
      }

    void Start(){
        if (targets == null){
            targets=GameObject.FindGameObjectsWithTag("Teleporter Target");
        }
    }
}
