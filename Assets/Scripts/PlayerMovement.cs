using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;
    public float runspeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool crouch = false;
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            Debug.Log("Crouch button down");
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            Debug.Log("Crouch button up");
        }
    }


    void FixedUpdate ()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        // crouch = false;
    }
}
