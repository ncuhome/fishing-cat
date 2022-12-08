using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//道具插槽，控制道具的自动排列和自动装配道具精灵，挂载在slot预制体上
public class Slot : MonoBehaviour
{
    public Item slotItem;//
    public Image slotImage;
    public Text slotNum;

    //点击道具则显示描述信息
    public void ItemOnClicked()
    {
    
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
        InventoryManager.onChoosedItem = this;
        
    }
}
