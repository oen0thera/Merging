using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//김원진 - 아이템 습득시 인벤토리 추가
public class GetItem : MonoBehaviour
{
    public Items Items;

    public void Get()
    {
        InventoryManager.Instance.addItem(Items);
        Destroy(gameObject);
    }
}
