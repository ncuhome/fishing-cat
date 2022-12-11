using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//背包管理器，挂载在Canvas上
public class InventoryManager : MonoBehaviour
{


    public static Slot onChoosedItem;
    static InventoryManager instance;
    

    public Inventory Bag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInformation;


    private void Awake()
    {
        if (instance != null) Destroy(this);
        instance = this;
    }

    private void OnEnable()
    {
        RefreshItem();
        //道具描述默认为空
        instance.itemInformation.text = "";
    }

    //控制道具描述信息的显示
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInformation.text = itemDescription;
    }
    //如果背包中不存在该道具，则在背包面板中添加该道具
    public static void CreateNewItem(Item item)
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        if (newItem.slotItem.itemHeld == 0) newItem.slotItem.itemHeld = 1;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    }


    //控制道具数目的显示变化
    public static void RefreshItem()
    {
        //先摧毁包中所有道具
        for(int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            //if (instance.slotGrid.transform.childCount == 0) break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        //遍历重新生成
        for(int i = 0; i < instance.Bag.itemList.Count; i++)
        {
            CreateNewItem(instance.Bag.itemList[i]);
        }
    }


}
