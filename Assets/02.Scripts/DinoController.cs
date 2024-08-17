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
        anim.SetBool("isGround", true); // ó���� Run �ִϸ��̼� ����
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isGround", false); // Space�� Ű ���� �� Jump �ִϸ��̼� ����
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("isGround", true); // Space�� Ű �� �� Run �ִϸ��̼� ����
        }
    }
}
