using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoController : MonoBehaviour
{
    public float jumpForce;
    public bool isGrounded;
    public bool isDown;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isGround", true); // 처음에 Run 애니메이션 세팅
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isGround", false); // Space바 키 누를 때 Jump 애니메이션 세팅
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isGround", true); // Space바 키 뗄 때 Run 애니메이션 세팅
        }
    }
}
