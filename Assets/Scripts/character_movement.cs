  using UnityEngine;

public class character_movement : MonoBehaviour
{
    float speedX; 
    float speedY;
    public float speed;
    Rigidbody2D rb;
    private bool isFacingRight = true;

    private Animator anim;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       speedX = Input.GetAxisRaw("Horizontal") * speed;
       speedY = Input.GetAxisRaw("Vertical") * speed;
       rb.linearVelocity = new Vector2(speedX, rb.linearVelocity.y);
       //rb.linearVelocity = new Vector2(speedX, speedY);
       if(speedX != 0)
       {
            anim.SetBool("isWalking", true);
       }
       else
       {
            anim.SetBool("isWalking", false);
       }
       Flip();
    }

    private void Flip()
    {
        if(isFacingRight && speedX < 0f || !isFacingRight && speedX > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }
    }
}
