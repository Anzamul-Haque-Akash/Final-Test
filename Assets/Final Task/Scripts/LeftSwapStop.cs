using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSwapStop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Added")
        {
            PlayerController.playerControllerClass.leftSwapStop = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Added")
        {
            PlayerController.playerControllerClass.leftSwapStop = false;
        }
    }

}//CLASS
