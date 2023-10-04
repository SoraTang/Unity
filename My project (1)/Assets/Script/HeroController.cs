using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        // ��ȡ�û�������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �����ƶ�����
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * moveSpeed * Time.deltaTime;

        // ���½�ɫλ��
        transform.Translate(movement, Space.World);
    }
}

