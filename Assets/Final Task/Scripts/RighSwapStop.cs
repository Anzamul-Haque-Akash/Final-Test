using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RighSwapStop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Added")
        {
            PlayerController.playerControllerClass.rightSwapStop = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Added")
        {
            PlayerController.playerControllerClass.rightSwapStop = false;
        }
    }

}//CLASS
