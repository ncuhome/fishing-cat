using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//该脚步挂载在当前场景中可获取的道具上
public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;//目标背包



    public void Start()
    {
        if(thisItem.itemHeld > 0)
        AddNewItem();
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
        }
        //刷新背包
        InventoryManager.RefreshItem(); 
    }
}
