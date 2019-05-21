using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public Joystick joystick;
    public float speed;
    public Animator animator;


    Vector2 move;
    bool flip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = joystick.Direction * speed; //Должно быть уже нормализовано джойстиком

        animator.SetBool("Walk", System.Math.Abs(joystick.Horizontal) > 0.0f);

        if (joystick.Horizontal > 0 && flip || joystick.Horizontal < 0.0f && !flip)
        {
            flip = !flip;
            Vector2 tmp = transform.localScale;
            tmp.x *= -1;
            transform.localScale = tmp;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * Time.deltaTime);

    }
}
