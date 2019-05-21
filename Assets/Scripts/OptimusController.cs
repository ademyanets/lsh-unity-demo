using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimusController : MonoBehaviour
{
    public CharacterController2D controller;
    public Joystick joystick;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    
    // Update is called once per frame
    void Update () {

        horizontalMove = joystick.Horizontal * runSpeed;
        Debug.Log(horizontalMove);

   //     if (Input.GetButtonDown("Jump"))
        //{
            jump = true;
        //}

     //   if (Input.GetButtonDown("Crouch"))
        //{
            crouch = true;
       // } else if (Input.GetButtonUp("Crouch"))
        //{
            crouch = false;
        //}
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
//    public const float EPSILON = 0.0001f;
//    public Joystick joystick;
//    public Animator animator;
//    public float runSpeed = 25.0f;
//    public Rigidbody2D rb;

//    Vector2 move;
//    bool isJumping;
//    bool rotated;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = this.GetComponent<Rigidbody2D>();
//        move = new Vector2(0.0f, 0.0f);
//        isJumping = false;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (!isJumping && joystick.Vertical > EPSILON)
//        {
//            isJumping = true;
//        }

//        move = new Vector2(joystick.Horizontal, joystick.Vertical);
//        switchAnimation(move);
//    }

//    private void FixedUpdate()
//    {
//        moveCharacter(move, isJumping);
//        jump = false;

//    }

//    private void moveCharacter(Vector2 direction, bool isJumping)
//    {   
//        if (isJumping)
//        {
//            rb.AddForce(Vector3.up * 1, ForceMode2D.Impulse);
//        } 

//        rb.MovePosition((Vector2)transform.position + (direction * runSpeed * Time.deltaTime));
//    }

//    private void switchAnimation(Vector2 move) {
//        animator.SetBool("Walk", System.Math.Abs(move.x) > EPSILON);
//        isJumping = move.y > EPSILON;

//        //animator.SetBool("HorizontalMove", isMoving);
//        //transform.localScale = flipValue;//to not duplicate left / right animations
//    }
//}

/*
 * 
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Joystick joystick;
    public Animator animator;
    public float runSpeed = 5.0f;
    public Rigidbody2D rb;
    public B

    class MovementState
    {
        public const float EPSILON = 0.0001f;
        Vector2 movement;
        bool isFlipped;
        int flip;

        public MovementState()
        {
            movement = new Vector2(0.0f, 0.0f);
            isFlipped = false;
            flip = 1;
        }

        public void setMove(Vector2 newMove) 
        {
            movement = newMove;

            if (newMove.x > EPSILON && !isFlipped || newMove.x < -EPSILON && isFlipped)
            {
                isFlipped = !isFlipped;
                flip = -1;
            }
            else 
            {
                flip = 1;
            }
        }

        public Vector2 getMoveValue() {
            return movement;
        }

        public bool isMoving() 
        { 
            return System.Math.Abs(movement.x) > MovementState.EPSILON;
        }


        public Vector3 flipValue(Vector3 scale) 
        {
            scale.x *= flip;
            return scale;
        }
    }
    private MovementState movement;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        movement = new MovementState();
    }

    private void Update()
    {
        movement.setMove(new Vector2(joystick.Horizontal, joystick.Vertical));
    }

    private void FixedUpdate()
    {
        moveCharacter(movement.getMoveValue());
        switchAnimation(movement.isMoving(), movement.flipValue(transform.localScale));
    }

    private void moveCharacter(Vector2 direction)
    {   
        //jump 
        if (direction.y > 0.0f)
        {
            rb.AddForce(Vector3.up * 1, ForceMode2D.Impulse);
        } 

        rb.MovePosition((Vector2)transform.position + (direction * runSpeed * Time.deltaTime));
    }

    private void switchAnimation(bool isMoving, Vector3  flipValue) {

        animator.SetBool("HorizontalMove", isMoving);
        transform.localScale = flipValue;//to not duplicate left / right animations
    }
}

*/
