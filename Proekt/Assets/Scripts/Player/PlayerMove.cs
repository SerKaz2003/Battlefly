using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public int hp = 10;

    PhotonView view;
    public Text name;
    public Text health;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody2D>();
        name.text = view.Owner.NickName;

        if(view.Owner.IsLocal)
        {
            Camera.main.GetComponent<CameraFollow>().player = gameObject.transform;
        }
    }
    private void Update()
    {
        health.text = hp.ToString();
        if (view.IsMine)
        {
            if(hp<=0)
            {
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene(0);
            }
            if (isGrounded)
            {
               if (Input.GetKeyDown(KeyCode.Space))
               {
                 rb.velocity = Vector2.up * jumpForce;
               }
                
            }
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
            health.text = hp.ToString();
            moveInput = Input.GetAxis("Horizontal");
            if (moveInput < 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                name.transform.eulerAngles = new Vector3(0, 0, 0);
                health.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            if (moveInput > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                name.transform.eulerAngles = new Vector3(0, 0, 0);
                health.transform.eulerAngles = new Vector3(0, 0, 0);
            }
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


            if (hp <= 0)
            {
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene(0);
            }
            if (isGrounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    rb.velocity = Vector2.up * jumpForce;
                }

            }
        }
    }
}
