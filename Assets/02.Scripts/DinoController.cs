using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public bool isDown;

    public Transform groundCheckPoint;  // 빨간 점의 위치
    public LayerMask whatIsGround;       // Ground인지 비교할 LayerMask

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("isGround", true); // 처음에 Run 애니메이션 세팅
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Equals(true))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Dino의 가속도를 y방향으로 jumpForce만큼 준다.
        }

        anim.SetBool("isGround", isGrounded); // isGrounded의 값에 따라 자동으로 애니메이션 실행
    }
}
