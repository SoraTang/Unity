using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public static BackgroundMusicManager instance;

    public AudioClip[] bgmTracks;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayBGM(int trackIndex)
    {
        if (trackIndex >= 0 && trackIndex < bgmTracks.Length)
        {
            audioSource.clip = bgmTracks[trackIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid BGM track index");
        }
    }
}
