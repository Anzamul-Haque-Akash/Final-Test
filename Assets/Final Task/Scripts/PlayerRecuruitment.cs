using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerRecuruitment : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Add")) //Comp using tags
        {
            other.gameObject.tag = "Added"; //Update add charcter tag to Added if character added.

            PlayerController.playerControllerClass.Rblst.Add(other.collider.GetComponent<Rigidbody>());

            other.transform.parent = null; //Unparent that object

            other.transform.parent = PlayerController.playerControllerClass.transform; //Set new parent

            if (!other.collider.gameObject.GetComponent<PlayerRecuruitment>())
            {
                other.collider.gameObject.AddComponent<PlayerRecuruitment>();
            }

            other.collider.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material =
                PlayerController.playerControllerClass.Rblst.ElementAt(0).transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().material; //Same as patent material

        }
    }
}//CLASS
