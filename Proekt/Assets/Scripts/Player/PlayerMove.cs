using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool PlayerOne;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (PlayerOne)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveInput = -1;
            }
            else
            {
                if (Input.GetKey(KeyCode.D))
                {
                    moveInput = 1;
                }
                else
                {
                    moveInput = 0;
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveInput = -1;
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    moveInput = 1;
                }
                else
                {
                    moveInput = 0;
                }
            }
        }
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
    private void Update()
    {
        if (isGrounded)
        {
            if (PlayerOne)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    rb.velocity = Vector2.up * jumpForce;

                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Insert))
                {
                    rb.velocity = Vector2.up * jumpForce;

                }
            }
        }
    }
}
