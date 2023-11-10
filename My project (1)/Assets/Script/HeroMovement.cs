using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public GameObject idleUI; // 静止状态的UI
    public GameObject movingUI; // 移动状态的UI

    private Rigidbody2D rb;
    public AudioClip footstepSound;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        SetUIState(true); // 开始时显示静止状态的UI
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        movement.Normalize(); // 防止对角线移动速度过快

        rb.velocity = movement * moveSpeed;

        if (rb.velocity.magnitude > 0.2f && !audioSource.isPlaying)
        {
            PlayFootstepSound();
            SetUIState(false); // 切换到移动状态的UI
        }
        if (rb.velocity.magnitude < 0.2f && audioSource.isPlaying)
        {
            StopFootstepSound();
            SetUIState(true); // 切换到静止状态的UI
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