using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneSwitchCounter : MonoBehaviour
{
    private static SceneSwitchCounter instance;

    private int sceneSwitchCount = 0;
    public TextMeshProUGUI counterText;

    void Awake()
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
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        counterText.text = "Scene Switch Count: " + sceneSwitchCount;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this == instance) // 确保只有主计数器更新
        {
            sceneSwitchCount++;
            counterText.text = "Scene Switch Count: " + sceneSwitchCount;
        }
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
