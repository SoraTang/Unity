
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public string nextSceneName; // 下一个场景的名称
    public Transform initialPosition;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // 确保只有玩家触发了终点
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
        // 设置初始位置
        if (initialPosition != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = initialPosition.position;
        }
    }
    }
