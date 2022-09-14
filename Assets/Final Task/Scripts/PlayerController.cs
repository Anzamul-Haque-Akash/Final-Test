using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_start = false; //Game start bool

    private Rigidbody rb; //Character Rigitbody
    [SerializeField] Animator anim; //character animator

    [SerializeField] private float m_forwedSpeed;
    [SerializeField] private float m_swapSpeed;
    private Vector2 initialPosition;
    //[SerializeField] private float m_sidewaysForce;

    bool m_playerMoveLeftRIght;

    Touch touch;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetChild(0).GetComponent<Rigidbody>(); //Get Character Rigitbody
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1) //Player Touch count
        {
            touch = Input.GetTouch(0);
            m_playerMoveLeftRIght = true; //Player can move

            m_start = true; //game start at the first touch
        }
        else
        {
            m_playerMoveLeftRIght = false; //Player can not move
        }
    }

    //Fixed Update function for apply character physic functions
    private void FixedUpdate()
    {
        if (m_start)
        {
            PlayerAnimations("ForwardRun"); 

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + m_forwedSpeed); //Character Move forward

            if (m_playerMoveLeftRIght)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    initialPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    var direction = touch.position - initialPosition;
                    rb.velocity = new Vector3(direction.x * Time.fixedDeltaTime * m_swapSpeed, 0f, 0f);
                }
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
    }

    //All Character animations play from this functions 
    public void PlayerAnimations(string s)
    {
        switch (s) //Animation conditions here
        {
            case "ForwardRun": //Run animation play
                anim.SetBool("isRun", true);
                break;
        }
    }

}//CLASS
