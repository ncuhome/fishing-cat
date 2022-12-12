using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{

    public Inventory Bag;
    
    public void UseItem()
    {
        if (InventoryManager.onChoosedItem == null) return;
        else
        {
            int slotNum = InventoryManager.onChoosedItem.slotItem.itemHeld;
            Debug.Log(slotNum);
            if(slotNum > 1)
            {
                InventoryManager.onChoosedItem.slotItem.itemHeld--;
                InventoryManager.RefreshItem();
            }
            if(slotNum == 1)
            {
                InventoryManager.onChoosedItem.slotItem.itemHeld = 0;
                Bag.itemList.Remove(InventoryManager.onChoosedItem.slotItem);
                InventoryManager.UpdateItemInfo("");
                Destroy(InventoryManager.onChoosedItem.gameObject);
            }

        }
    }

}
