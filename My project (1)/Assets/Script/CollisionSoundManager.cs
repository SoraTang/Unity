using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundManager : MonoBehaviour
{
    public AudioClip defaultCollisionSound;
    public AudioClip wallCollisionSound;
    public AudioClip FinishCollisionSound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayCollisionSound(wallCollisionSound);
        }
        else if (collision.gameObject.CompareTag("Finish"))
        {
            PlayCollisionSound(FinishCollisionSound);
        }
        else
        {
            PlayCollisionSound(defaultCollisionSound);
        }
    }

    void PlayCollisionSound(AudioClip clip)
    {
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
