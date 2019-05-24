using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Joystick joystick;
    public float speed;
    public Animator animator;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float jumpForce = 8.0f;
    public int extaJumpsCount = 2;
    public LayerMask whatIsGround;

    Vector2 move;
    bool flip;
    bool isGrounded;
    bool isDoubleJumpAvailable;
    int jumpsCount;


    // Start is called before the first frame update
    void awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsCount = extaJumpsCount;
        isDoubleJumpAvailable = false;
    }

    // Update is called once per frame
    void Update()
    {
        move = joystick.Direction;//new Vector2(joystick.Horizontal, 0.0f) * speed; // почему не работает new Vector2(joystick.Horizontal, rb.position.y).normalized * speed;

        animator.SetBool("Walk", System.Math.Abs(joystick.Horizontal) > 0.0f);

        if (joystick.Horizontal > 0 && flip || joystick.Horizontal < 0.0f && !flip)
        {
            flip = !flip;
            Vector2 tmp = transform.localScale;
            tmp.x *= -1;
            transform.localScale = tmp;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround); //1 << LayerMask.NameToLayer("Ground")); //whatIsGround);
        animator.SetBool("Jump", !isGrounded);
        if (move.y > 0.0f)
        {
            if (isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpsCount = extaJumpsCount;
                isDoubleJumpAvailable = false;
            } 
            else if (jumpsCount > 0 && isDoubleJumpAvailable) 
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpsCount--;
            }
        } else {
            if (!isGrounded)
            {
                isDoubleJumpAvailable = true;
            }
            animator.SetBool("Crouch", isGrounded && move.y < 0);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
    }
}
