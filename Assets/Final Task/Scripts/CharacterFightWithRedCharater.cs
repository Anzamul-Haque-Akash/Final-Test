using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFightWithRedCharater : MonoBehaviour
{ 
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player" || other.transform.tag == "Add")
        {
            PlayerController.m_start = false; //Player move stop
            RedCharacterAttack.m_enemyStartAttacking = true; //Enemy Start attacking
        }
    }

}//CLASS
