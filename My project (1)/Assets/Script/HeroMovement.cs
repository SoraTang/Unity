using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject idleUI; // ��ֹ״̬��UI
    public GameObject movingUI; // �ƶ�״̬��UI

    private Rigidbody2D rb;
    public AudioClip footstepSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        SetUIState(true); // ��ʼʱ��ʾ��ֹ״̬��UI
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement.Normalize(); // ��ֹ�Խ����ƶ��ٶȹ���

        rb.velocity = movement * moveSpeed;

        if (rb.velocity.magnitude > 0.2f && !audioSource.isPlaying)
        {
            PlayFootstepSound();
            SetUIState(false); // �л����ƶ�״̬��UI
        }
        if (rb.velocity.magnitude < 0.2f && audioSource.isPlaying)
        {
            StopFootstepSound();
            SetUIState(true); // �л�����ֹ״̬��UI
        }
    }

    void PlayFootstepSound()
    {
        audioSource.clip = footstepSound;
        audioSource.Play();
    }

    void StopFootstepSound()
    {
        audioSource.Stop();
    }

    void SetUIState(bool idle)
    {
        idleUI.SetActive(idle);
        movingUI.SetActive(!idle);
    }
}