using UnityEngine;
using TMPro;

public class PersistentTMP : MonoBehaviour
{
    private static PersistentTMP instance;
    public TextMeshProUGUI tmpText;

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
        tmpText.text = "Count:";
    }
}
