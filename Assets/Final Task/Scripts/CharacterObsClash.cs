using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObsClash : MonoBehaviour
{
    [SerializeField] GameObject Particle_Death; 

    private void OnTriggerEnter(Collider other) //Collide with Obs
    {
        if (other.transform.tag == "Obs")
        {
            Instantiate(Particle_Death, transform.position, Quaternion.identity); //Hit partical

            gameObject.tag = "Untagged";

            gameObject.SetActive(false);

            transform.parent = null;
        }
    }

}//CLASS
