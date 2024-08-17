using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public bool isDown;

    public Transform groundCheckPoint;  // ���� ���� ��ġ
    public LayerMask whatIsGround;       // Ground���� ���� LayerMask

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isGround", true); // ó���� Run �ִϸ��̼� ����
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Equals(true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Dino�� ���ӵ��� y�������� jumpForce��ŭ �ش�.
        }

        anim.SetBool("isGround", isGrounded); // isGrounded�� ���� ���� �ڵ����� �ִϸ��̼� ����
    }
}
