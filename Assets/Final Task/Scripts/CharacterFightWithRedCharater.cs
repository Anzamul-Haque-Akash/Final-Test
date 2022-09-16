using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFightWithRedCharater : MonoBehaviour
{

    public static GameObject[] m_CharacterFightWithRedEnemy; //First <= 4  charaacter added

    private void OnTriggerEnter(Collider other) //Character attacking position enter
    {
        if(other.transform.tag == "Player" || other.transform.tag == "Added")
        {
            m_CharacterFightWithRedEnemy = GameObject.FindGameObjectsWithTag("Added");

            RedCharacterAttack.m_enemyStartAttacking = true; //Enemy Start attacking
        }
    }

    private void Update()
    {
        
        if (RedCharacterAttack.m_enemyStartAttacking && m_CharacterFightWithRedEnemy.Length >= 4) //4 character attacking
        {
            for (int i = 0; i < 4; i++)
            {
                m_CharacterFightWithRedEnemy[i].GetComponent<CapsuleCollider>().enabled = false;
                m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>().isKinematic = true;
                m_CharacterFightWithRedEnemy[i].transform.parent = null;
            }
            for (int i = 0; i < 4; i++)
            {
                if (Vector3.Distance(m_CharacterFightWithRedEnemy[i].transform.position, RedCharacterAttack.redCharacterAttackClass.m_redCharacter[i].transform.position) > 0.4f)
                {
                    PlayerController.playerControllerClass.RunAnimation(m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>());

                    m_CharacterFightWithRedEnemy[i].transform.position = Vector3.MoveTowards(m_CharacterFightWithRedEnemy[i].transform.position,
                    RedCharacterAttack.redCharacterAttackClass.m_redCharacter[i].transform.position, RedCharacterAttack.redCharacterAttackClass.m_speed * Time.deltaTime);
                }
                else
                {
                    PlayerController.playerControllerClass.DeathAnimation(m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>());
                }
            }
        }
        else if(RedCharacterAttack.m_enemyStartAttacking && m_CharacterFightWithRedEnemy.Length < 4 && CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy.Length > 0) //Less then 4 charater attacking
        {
            for (int i = 0; i < m_CharacterFightWithRedEnemy.Length; i++)
            {
                m_CharacterFightWithRedEnemy[i].GetComponent<CapsuleCollider>().enabled = false;
                m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>().isKinematic = true;
                m_CharacterFightWithRedEnemy[i].transform.parent = null;
            }
            for (int i = 0; i < m_CharacterFightWithRedEnemy.Length; i++)
            {
                if (Vector3.Distance(m_CharacterFightWithRedEnemy[i].transform.position, RedCharacterAttack.redCharacterAttackClass.m_redCharacter[i].transform.position) > 0.2f)
                {
                    PlayerController.playerControllerClass.RunAnimation(m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>());

                    m_CharacterFightWithRedEnemy[i].transform.position = Vector3.MoveTowards(m_CharacterFightWithRedEnemy[i].transform.position,
                    RedCharacterAttack.redCharacterAttackClass.m_redCharacter[i].transform.position, RedCharacterAttack.redCharacterAttackClass.m_speed * Time.deltaTime);
                }
                else
                {
                    PlayerController.playerControllerClass.DeathAnimation(m_CharacterFightWithRedEnemy[i].GetComponent<Rigidbody>());
                }
            }
        }
        
    }

}//CLASS 
