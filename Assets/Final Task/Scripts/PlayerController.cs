using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool m_start;
    public bool m_moveByTouch;
    

    private Vector3 Direction;
    public List<Rigidbody> Rblst = new List<Rigidbody>();
    [SerializeField] private float runSpeed, velocity, swipeSpeed;
    public static PlayerController playerControllerClass;

    void Start()
    {
        playerControllerClass = this;
        Rblst.Add(transform.GetChild(0).GetComponent<Rigidbody>());

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

            if (m_moveByTouch)
            {
                Direction.x = Mathf.Lerp(Direction.x, Input.GetAxis("Mouse X"), Time.deltaTime * runSpeed);

                Direction = Vector3.ClampMagnitude(Direction, 1f);
            }


            foreach (var stickman_rb in Rblst)
            {
                if (stickman_rb.velocity.magnitude > 0.5f)
                {
                    stickman_rb.transform.rotation = Quaternion.Slerp(stickman_rb.rotation, Quaternion.LookRotation(stickman_rb.velocity), Time.deltaTime * velocity);
                }
                else
                {
                    stickman_rb.transform.rotation = Quaternion.Slerp(stickman_rb.rotation, Quaternion.identity, Time.deltaTime * velocity);
                }
            }
        }

    }

    //Fixed Update Function-------------
    private void FixedUpdate()
    {
        if (m_start)
        {
            if (m_moveByTouch)
            {
                transform.Translate(Vector3.forward * runSpeed * Time.fixedDeltaTime); //Character move forward

                Vector3 displacement = new Vector3(Direction.x, 0f, 0f) * Time.fixedDeltaTime;

                foreach (var stickman_rb in Rblst)
                {
                    stickman_rb.velocity = new Vector3(Direction.x * Time.fixedDeltaTime * swipeSpeed, 0f, 0f) + displacement; //All Character move left and right

                    RunAnimation(stickman_rb);
                }
            }
            else
            {
                foreach (var stickman_rb in Rblst)
                {
                    stickman_rb.velocity = Vector3.zero;
                    IdleAnimation(stickman_rb);
                }
            }
        }
        else
        {
            foreach (var stickman_rb in Rblst)
            {
                stickman_rb.velocity = Vector3.zero;
                IdleAnimation(stickman_rb);
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
    //--------------------------------

}//CLASS
