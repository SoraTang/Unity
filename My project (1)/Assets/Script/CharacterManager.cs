using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject spirit;
    private SpriteRenderer spiritRenderer;
    public Color[] spiritColors;
    private int currentColorIndex = 0;

    void Start()
    {
        spiritRenderer = spirit.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentColorIndex = (currentColorIndex + 1) % spiritColors.Length;
            ChangeSpiritColor();
        }
    }

    void ChangeSpiritColor()
    {
        spiritRenderer.color = spiritColors[currentColorIndex];
    }
}
