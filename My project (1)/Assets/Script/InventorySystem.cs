using TMPro;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public TextMeshProUGUI inventoryText; // 在 Inspector 窗口中关联 TextMeshProUGUI 对象
    private bool inventoryVisible = true; // 背包是否可见的标志
    private string lastInventoryText = ""; // 上一帧的文本内容

    private void Start()
    {
        UpdateInventoryText(); // 初始化背包文本
    }

    private void Update()
    {
        // 检查是否需要获取最新的文本
        if (inventoryText.text != lastInventoryText)
        {
            lastInventoryText = inventoryText.text;

            // 在这里进行处理，例如输出到控制台
            Debug.Log("Current Inventory Text: " + lastInventoryText);
        }

        // 其他 Update 逻辑...
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickupItem"))
        {
            PickupItem pickupItem = other.GetComponent<PickupItem>();
            AddItemToInventory(pickupItem.itemName);

            // 隐藏拾取的物体
            other.gameObject.SetActive(false);
        }
    }

    public void AddItemToInventory(string itemName)
    {
        // 将物品添加到 TextMeshProUGUI 的文本中
        inventoryText.text += itemName + "\n";
    }

    private void UpdateInventoryText()
    {
        // 根据背包可见性设置 TextMeshProUGUI 的文本
        inventoryText.gameObject.SetActive(inventoryVisible);

        if (inventoryVisible)
        {
            // 更新背包文本内容
            inventoryText.text = "";
        }
    }
}
