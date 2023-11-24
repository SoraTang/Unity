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
        // �����ﴦ��ʰȡ�߼�
        Debug.Log("Picked up: " + itemName);

        // ��ʰȡ�ĵ�����Ϣ���浽PlayerPrefs��
        PlayerPrefs.SetInt("Item_" + itemID, 1);

        // Ȼ��������Ϸ����
        Destroy(gameObject);
    }
}
