using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public bool isDown;

    // offset과 size 값을 저장할 변수
    private Vector2 savedOffset;
    private Vector2 savedSize;
    // BoxCollider2D를 참조할 변수
    private BoxCollider2D boxCollider;

    public Transform groundCheckPoint;  // 빨간 점의 위치
    public LayerMask whatIsGround;       // Ground인지 비교할 LayerMask

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();// BoxCollider2D 컴포넌트를 가져옴
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SaveColliderSettings();
        anim.SetBool("isGround", true); // 처음에 Run 애니메이션 세팅
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded.Equals(true))
        {
            GetComponent<AudioSource>().Play();            // Jump 소리를 낸다.
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Dino의 가속도를 y방향으로 jumpForce만큼 준다.
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && isGrounded.Equals(true))  //땅에 닿은 상태에서 아래 화살표 키를 누르면.
        {
            SetDownArrowDown();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow)) // 아래 화살표 키를 떼면
        {
            SetDownArrowUp();
        }

        anim.SetBool("isGround", isGrounded); // isGrounded의 값에 따라 자동으로 애니메이션 실행
    }

    void SaveColliderSettings()
    {
        // 현재 offset과 size 값을 저장
        savedOffset = boxCollider.offset;
        savedSize = boxCollider.size;
    }

    void LoadColliderSettings()
    {
        // 저장된 offset과 size 값을 BoxCollider2D에 다시 적용
        boxCollider.offset = savedOffset;
        boxCollider.size = savedSize;
    }

    void SetDownArrowDown()
    {
        anim.SetBool("isDown", true); // Dino에니메이터에서 조건 isDown을 true로
        boxCollider.offset = new Vector2(0,-0.25f);
        boxCollider.size = new Vector2(1.39f,0.76f);
    }

    void SetDownArrowUp()
    {
        anim.SetBool("isDown", false);  // Dino에니메이터에서 조건 isDown을 false로
        LoadColliderSettings();
    }

    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            anim.SetTrigger("isDie");
            GameManager.instance.GameOver();  // 싱글톤을 접근 가능한 인스턴스를 통해 GameOver함수에 바로 접근.
        }
        else if(collision.CompareTag("Point"))
        {
            GameManager.instance.Score_UI_Update();  // 싱글톤을 접근 가능한 인스턴스를 통해 Score_UI_Update함수에 바로 접근.
        }
    }
}
