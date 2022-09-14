using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool m_start = false; //Game start bool

    public List<Rigidbody> rbList = new List<Rigidbody>(); //Character Rigitbody
    private Animator anim; //character animator

    [SerializeField] private float m_forwedSpeed;
    [SerializeField] private float m_swapSpeed;
    private Vector2 initialPosition;
    //[SerializeField] private float m_sidewaysForce;

    bool m_playerMoveLeftRIght;

    Touch touch;

    public static PlayerController playerControllerClass;
    

    // Start is called before the first frame update
    void Start()
    {
        playerControllerClass = this;
        rbList.Add(transform.GetChild(0).GetComponent<Rigidbody>()); //Get Characters Rigitbody
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
            
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + m_forwedSpeed); //Character Move forward

            if (m_playerMoveLeftRIght)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    initialPosition = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    foreach (var rb in rbList) //New Added
                    {
                       rb.GetComponent<Animator>();

                        var direction = touch.position - initialPosition;
                        rb.velocity = new Vector3(direction.x * Time.fixedDeltaTime * m_swapSpeed, 0f, 0f);


                        if (direction.x < 0f)
                        {
                            //PlayerAnimations("ForwardRunLeft"); //Player forward left move animation

                            rb.GetComponent<Animator>().SetBool("isLeft", true);
                            rb.GetComponent<Animator>().SetBool("isRun", false);
                            rb.GetComponent<Animator>().SetBool("isRight", false);
                        }
                        else if (direction.x > 0f)
                        {
                            //PlayerAnimations("ForwardRunRight"); //Player forward right move animation

                            rb.GetComponent<Animator>().SetBool("isLeft", false);
                            rb.GetComponent<Animator>().SetBool("isRun", false);
                            rb.GetComponent<Animator>().SetBool("isRight", true);
                        }
                    }
                }
            }
            else
            {
                foreach (var rb in rbList) //New Added
                {
                    rb.velocity = Vector3.zero;

                    rb.GetComponent<Animator>().SetBool("isLeft", false);
                    rb.GetComponent<Animator>().SetBool("isRun", true);
                    rb.GetComponent<Animator>().SetBool("isRight", false);
                }
            }
        }
    }

}//CLASS
