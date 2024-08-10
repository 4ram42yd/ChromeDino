using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = 1f; // X�� ��ũ�� �ӵ�
    private Renderer quadRenderer;

    public bool isCloud;    // �������� �ƴ��� �Ǵ��ϱ� ���� bool ������ Ÿ��, �����̸� true �ƴϸ� false.
    public float cloudScrollSpeedX = 0.5f;  // ������ �����̴� �ӵ�

    void Start()
    {
        quadRenderer = GetComponent<Renderer>();   // Quad�� Renderer�� ������
    }

    void Update()
    {
        if(isCloud)
        {
            // �� ��ũ��Ʈ�� �پ��ִ� ���� ������Ʈ�� ���� ��ǥ���� �������� ��� �������ش�.
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - cloudScrollSpeedX * Time.deltaTime,
                                                              this.gameObject.transform.position.y,
                                                              this.gameObject.transform.position.z);

            if (this.gameObject.transform.position.x <= -11f) // �� ���� ������Ʈ�� ��ǥ�� -11���� �۰ų� ������, 
            {
                this.gameObject.transform.position = new Vector3(11f, Random.Range(1f, 4f), 0f);  // �� ���� ������Ʈ�� 11, ������, 0�� ��ǥ�� �̵���
            }

        }
        else
        {
            // �ð��� ���� UV ������ ���� ���
            float offsetX = Time.time * scrollSpeedX;

            // Material�� ���� �ؽ�ó�� �������� ����
            quadRenderer.material.mainTextureOffset = new Vector2(offsetX, 0f);
        }
    }
}
