using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObsClash : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Obs")
        {
            this.gameObject.SetActive(false);
        }
    }

}//CLASS
