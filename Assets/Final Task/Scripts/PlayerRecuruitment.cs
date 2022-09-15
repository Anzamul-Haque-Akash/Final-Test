using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerRecuruitment : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Add"))
        {
            PlayerController.playerControllerClass.Rblst.Add(other.collider.GetComponent<Rigidbody>());

            other.transform.parent = null;

            other.transform.parent = PlayerController.playerControllerClass.transform;

            if (!other.collider.gameObject.GetComponent<PlayerRecuruitment>())
            {
                other.collider.gameObject.AddComponent<PlayerRecuruitment>();
            }

            other.collider.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material = PlayerController.playerControllerClass.Rblst.ElementAt(0).transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material; //Same as patent material

        }
    }
}//CLASS
