using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;//道具名称
    public Sprite itemImage;//道具图片精灵
    public int itemHeld;//目前持有道具数量
    public int itemID;
    [TextArea]
    public string itemInfo;//道具描述信息

    public bool equip;//道具是否可装备
}
