using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool m_start = false; //Game start bool

    public List<Rigidbody> rbList = new List<Rigidbody>(); //Character Rigitbody

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
        if (m_start)
        {
            if (Input.touchCount == 1) //Player Touch count
            {
                touch = Input.GetTouch(0);
                m_playerMoveLeftRIght = true; //Player can move
            }
            else
            {
                m_playerMoveLeftRIght = false; //Player can not move

                foreach (var rb in rbList)
                {
                    rb.GetComponent<Animator>().SetBool("isLeft", false);
                    rb.GetComponent<Animator>().SetBool("isRun", false);
                    rb.GetComponent<Animator>().SetBool("isRight", false);
                    rb.GetComponent<Animator>().SetBool("isIdle", true);
                }
            }
        }
    }

    //Fixed Update function for apply character physic functions
    private void FixedUpdate()
    {
        if (m_start)
        {
            if (m_playerMoveLeftRIght)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + m_forwedSpeed * Time.fixedDeltaTime); //Character Move forward

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


                        if (direction.x < 0f) //Player forward left move animation
                        {
                            rb.GetComponent<Animator>().SetBool("isLeft", true);
                            rb.GetComponent<Animator>().SetBool("isRun", false);
                            rb.GetComponent<Animator>().SetBool("isRight", false);
                            rb.GetComponent<Animator>().SetBool("isIdle", false);
                        }
                        else if (direction.x > 0f) //Player forward right move animation
                        {
                            rb.GetComponent<Animator>().SetBool("isLeft", false);
                            rb.GetComponent<Animator>().SetBool("isRun", false);
                            rb.GetComponent<Animator>().SetBool("isRight", true);
                            rb.GetComponent<Animator>().SetBool("isIdle", false);
                        }
                    }
                }
            }
            else
            {
                foreach (var rb in rbList)
                {
                    rb.GetComponent<Animator>().SetBool("isLeft", false);
                    rb.GetComponent<Animator>().SetBool("isRun", true);
                    rb.GetComponent<Animator>().SetBool("isRight", false);
                    rb.GetComponent<Animator>().SetBool("isIdle", false);
                }
            }
            
        }
    }

}//CLASS
