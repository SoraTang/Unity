using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName = "DefaultItem";
    public int itemID = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        // 在这里处理拾取逻辑
        Debug.Log("Picked up: " + itemName);

        // 将拾取的道具信息保存到PlayerPrefs中
        PlayerPrefs.SetInt("Item_" + itemID, 1);

        // 然后销毁游戏对象
        Destroy(gameObject);
    }
}
