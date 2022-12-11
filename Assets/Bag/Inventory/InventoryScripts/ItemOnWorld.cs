using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//该脚步挂载在当前场景中可获取的道具上
public class ItemOnWorld : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;//目标背包



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }
    }

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);
            //InventoryManager.CreateNewItem(thisItem);
        }
        else
        {
            //触碰到道具默认数量加1
            thisItem.itemHeld += 1;
        }
        //刷新背包
        InventoryManager.RefreshItem(); 
    }
}
