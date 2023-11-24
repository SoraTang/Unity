using System;
using TMPro;
using UnityEngine;

public class DropItemsFromInventory : MonoBehaviour
{
    public TextMeshProUGUI inventoryText;
    public GameObject[] itemsToDrop; // �����ƷԤ��������

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItemFromInventory();
        }
    }

    private void DropItemFromInventory()
    {
        // ��ȡ�����ı�����
        string inventoryContent = inventoryText.text;

        // ʹ�û��з��ָ��ַ������õ���Ʒ��������
        string[] itemNames = inventoryContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        if (itemNames.Length > 0)
        {
            // ��ȡҪ��������Ʒ���ƣ�ȥ�����˵Ŀո�
            string itemToDrop = itemNames[0].Trim();

            // �����ﴦ��������Ʒ���߼�
            if (itemsToDrop.Length > 0)
            {
                // ��˳��������Ӧ����Ʒ������λ��Ϊ���ǰ���Ҳ�
                Instantiate(itemsToDrop[0], transform.position + new Vector3(2f, 0f, 0f), Quaternion.identity);
            }

            // �Ƴ������еĶ�Ӧ��Ʒ
            inventoryContent = inventoryContent.Replace(itemToDrop, "").Trim();

            // ���±����ı�
            inventoryText.text = inventoryContent;
        }
        else
        {
            Debug.Log("Inventory is empty");
        }
    }
}
