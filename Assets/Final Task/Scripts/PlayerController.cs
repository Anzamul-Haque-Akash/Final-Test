using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool m_start; //Game Start bool
    public bool m_moveByTouch; //Scrren tiuch or not
   
    private Vector3 Direction; 
    public List<Rigidbody> Rblst = new List<Rigidbody>(); //All added character rigidbodys
    [SerializeField] private float runSpeed, velocity, swipeSpeed; //Run, velocity and swiping speed
    public static PlayerController playerControllerClass; //Class

    public bool rightSwapStop = false;
    public  bool leftSwapStop = false;

    void Start()
    {
        playerControllerClass = this;
        Rblst.Add(transform.GetChild(0).GetComponent<Rigidbody>()); //Get stating charaacter rigidbody
    }

    void Update()
    {
        if (m_start)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_moveByTouch = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                m_moveByTouch = false;
            }


            if (m_moveByTouch) //touch left right dect
            {
                Direction.x = Mathf.Lerp(Direction.x, Input.GetAxis("Mouse X"), Time.deltaTime * runSpeed);

                if((rightSwapStop && Direction.x > 0f) || (leftSwapStop && Direction.x < 0f)) //Stop player for going (left and right) out side.
                {
                    Direction.x = 0;
                }

                Direction = Vector3.ClampMagnitude(Direction, 1f);
            }
            else
            {
                Direction.x = 0f;
            }



            foreach (var rb in Rblst) //For Charater Rotate left and right
            {
                if (rb.velocity.magnitude > 0.5f)
                {
                    rb.transform.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(rb.velocity), Time.deltaTime * velocity);
                }
                else
                {
                    rb.transform.rotation = Quaternion.Slerp(rb.rotation, Quaternion.identity, Time.deltaTime * velocity);
                }
            }
        }

    }

    //Fixed Update Function-------------
    private void FixedUpdate()
    {
        if (m_start) //If game start
        {
            if (m_moveByTouch)
            {
                transform.Translate(Vector3.forward * runSpeed * Time.fixedDeltaTime); //Character move forward

                Vector3 displacement = new Vector3(Direction.x, 0f, 0f) * Time.fixedDeltaTime;

                foreach (var rb in Rblst)
                {
                    rb.velocity = new Vector3(Direction.x * Time.fixedDeltaTime * swipeSpeed, 0f, 0f) + displacement; //All Character move left and right

                    RunAnimation(rb);
                }
            }
            else //stop and idle mode
            {
                foreach (var rb in Rblst)
                {
                    rb.velocity = Vector3.zero;
                    IdleAnimation(rb);
                }
            }
        }
        else
        {
            foreach (var rb in Rblst)
            {
                rb.velocity = Vector3.zero;
                IdleAnimation(rb);
            }
        }
    }

    //Character Animations------------
    public void IdleAnimation(Rigidbody rb)
    {
        rb.GetComponent<Animator>().SetBool("isIdle", true);
        rb.GetComponent<Animator>().SetBool("isRun", false);
    }
    public void RunAnimation(Rigidbody rb)
    {
        rb.GetComponent<Animator>().SetBool("isRun", true);
        rb.GetComponent<Animator>().SetBool("isIdle", false); 
    }
    public void DeathAnimation(Rigidbody rb)
    {
        rb.GetComponent<Animator>().SetBool("isDeath", true);
        rb.GetComponent<Animator>().SetBool("isRun", false);
        rb.GetComponent<Animator>().SetBool("isIdle", false);
    }
    //--------------------------------

}//CLASS
