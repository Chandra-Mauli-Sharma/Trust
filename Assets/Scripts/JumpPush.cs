using UnityEngine;
using StarterAssets;

public class JumpPush : MonoBehaviour
{
    void OnTriggerEnter(Collider others)
    {
        var thirdPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        thirdPersonController.JumpHeight=30;
        thirdPersonController.TriggerJump=true;
    }

    void OnTriggerExit(Collider others)
    {
        var thirdPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        thirdPersonController.JumpHeight=10;
        thirdPersonController.TriggerJump=false;
    }
}
