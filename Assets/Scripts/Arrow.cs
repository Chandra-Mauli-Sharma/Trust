using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform[] destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(destination.Length==2)
        {
            if(Vector3.Distance(transform.position,destination[1].position)> Vector3.Distance(transform.position,destination[0].position))
                transform.LookAt(destination[0]);
            if(Vector3.Distance(transform.position,destination[1].position)< Vector3.Distance(transform.position,destination[0].position))
                transform.LookAt(destination[1]);
        }
        else{
            transform.LookAt(destination[0]);
        }
    }
}
