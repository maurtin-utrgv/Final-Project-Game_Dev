using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class robot_move : MonoBehaviour
{
    float speedX; 
    float speedY;
    public float speed;
    Rigidbody2D rb;
    private bool isFacingRight = true;
    public float jump;
    public Transform inGround;
    public LayerMask groundLayer;
    bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       isGrounded = Physics2D.OverlapCapsule(inGround.position, new Vector2(2.5f, 1.0f), CapsuleDirection2D.Horizontal,0,groundLayer);
       speedX = Input.GetAxisRaw("Horizontal") * speed;
       //speedY = Input.GetAxisRaw("Vertical") * speed;
       if(Input.GetButton("Jump") & isGrounded)//if(Input.GetButton("Jump") && isGrounded)
       {
        rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
       }
       rb.linearVelocity = new Vector2(speedX, speedY);
       Flip();
    }

    private void Flip()
    {
        if(isFacingRight && speedX > 0f || !isFacingRight && speedX < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }
    }
}
