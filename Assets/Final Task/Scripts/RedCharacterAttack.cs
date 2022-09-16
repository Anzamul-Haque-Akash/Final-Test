using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCharacterAttack : MonoBehaviour
{
    [SerializeField] List<GameObject> m_redCharacter = new List<GameObject>();
    public static bool m_enemyStartAttacking;

    [SerializeField] List<Transform> tempTarget = new List<Transform>();

    [Range(1f,10f)]
    [SerializeField] float m_speed;

    // Update is called once per frame
    void Update()
    {
        if (m_enemyStartAttacking)
        {
            int i = 0;

            foreach(GameObject g in m_redCharacter)
            {
                g.transform.LookAt(tempTarget[i]);


                g.transform.position = Vector3.MoveTowards(g.transform.position, tempTarget[i].transform.position, m_speed * Time.deltaTime);


                i++;
            }
        }
    }

}//CLASS
