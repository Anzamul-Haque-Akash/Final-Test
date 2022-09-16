using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCharacterAttack : MonoBehaviour
{
    [SerializeField] List<Animator> anim = new List<Animator>();

    public List<GameObject> m_redCharacter = new List<GameObject>();
    public static bool m_enemyStartAttacking;

    [Range(1f,10f)]
    public float m_speed;


    public static RedCharacterAttack redCharacterAttackClass;

    private void Start()
    {
        redCharacterAttackClass = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_enemyStartAttacking && CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy.Length >= 4) //All 4 red charater attaking
        {
            int i = 0;

            foreach (GameObject g in m_redCharacter)
            {
                if (Vector3.Distance(g.transform.position, CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy[i].transform.position) > 0.4f)
                {
                    g.transform.LookAt(CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy[i].transform);

                    anim[i].SetBool("isRun", true);

                    g.transform.position = Vector3.MoveTowards(g.transform.position, CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy[i].transform.position, m_speed * Time.deltaTime);
                }
                else
                {
                    anim[i].SetBool("isRun", false);
                    anim[i].SetBool("isDeath", true);
                }

                i++;
            }

        }
        else if(m_enemyStartAttacking && CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy.Length < 4 && CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy.Length > 0) //Less then 4 red character attacking
        {
            int i = 0;

            foreach (GameObject g in m_redCharacter)
            {
                if(CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy.Length == i)
                {
                    break;
                }

                if (Vector3.Distance(g.transform.position, CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy[i].transform.position) > 0.2f)
                {
                    g.transform.LookAt(CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy[i].transform);

                    anim[i].SetBool("isRun", true);

                    g.transform.position = Vector3.MoveTowards(g.transform.position, CharacterFightWithRedCharater.m_CharacterFightWithRedEnemy[i].transform.position, m_speed * Time.deltaTime);
                }
                else
                {
                    anim[i].SetBool("isRun", false);
                    anim[i].SetBool("isDeath", true);
                }

                i++;
            }

        }
    }

}//CLASS
