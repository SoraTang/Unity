using System;
using TMPro;
using UnityEngine;

public class DropItemsFromInventory : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public GameObject[] itemsToDrop; // 你的物品预制体数组

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItemFromInventory();
        }
    }

    private void DropItemFromInventory()
    {
        // 获取背包文本内容
        string inventoryContent = inventoryText.text;

        // 使用换行符分割字符串，得到物品名称数组
        string[] itemNames = inventoryContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        if (itemNames.Length > 0)
        {
            // 获取要丢弃的物品名称（去除两端的空格）
            string itemToDrop = itemNames[0].Trim();

            // 在这里处理生成物品的逻辑
            if (itemsToDrop.Length > 0)
            {
                // 按顺序生成相应的物品，生成位置为玩家前方右侧
                Instantiate(itemsToDrop[0], transform.position + new Vector3(2f, 0f, 0f), Quaternion.identity);
            }

            // 移除背包中的对应物品
            inventoryContent = inventoryContent.Replace(itemToDrop, "").Trim();

            // 更新背包文本
            inventoryText.text = inventoryContent;
        }
        else
        {
            Debug.Log("Inventory is empty");
        }
    }
}
