
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string nextSceneName; // ��һ������������
    public Transform initialPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ȷ��ֻ����Ҵ������յ�
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
    void Start()
    {
        // ���ó�ʼλ��
        if (initialPosition != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = initialPosition.position;
        }
    }
    }
