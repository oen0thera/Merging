using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����� - ������ ����� �κ��丮 �߰�
public class GetItem : MonoBehaviour
{
    public Items Items;

    public void Get()
    {
        InventoryManager.Instance.addItem(Items);
        Destroy(gameObject);
    }
}
