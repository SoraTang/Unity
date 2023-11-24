using TMPro;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public TextMeshProUGUI inventoryText; // �� Inspector �����й��� TextMeshProUGUI ����
    private bool inventoryVisible = true; // �����Ƿ�ɼ��ı�־
    private string lastInventoryText = ""; // ��һ֡���ı�����

    private void Start()
    {
        UpdateInventoryText(); // ��ʼ�������ı�
    }

    private void Update()
    {
        // ����Ƿ���Ҫ��ȡ���µ��ı�
        if (inventoryText.text != lastInventoryText)
        {
            lastInventoryText = inventoryText.text;

            // ��������д����������������̨
            Debug.Log("Current Inventory Text: " + lastInventoryText);
        }

        // ���� Update �߼�...
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PickupItem"))
        {
            PickupItem pickupItem = other.GetComponent<PickupItem>();
            AddItemToInventory(pickupItem.itemName);

            // ����ʰȡ������
            other.gameObject.SetActive(false);
        }
    }

    public void AddItemToInventory(string itemName)
    {
        // ����Ʒ��ӵ� TextMeshProUGUI ���ı���
        inventoryText.text += itemName + "\n";
    }

    private void UpdateInventoryText()
    {
        // ���ݱ����ɼ������� TextMeshProUGUI ���ı�
        inventoryText.gameObject.SetActive(inventoryVisible);

        if (inventoryVisible)
        {
            // ���±����ı�����
            inventoryText.text = "";
        }
    }
}
