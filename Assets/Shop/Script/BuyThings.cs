using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class BuyThings : MonoBehaviour
{
    public int price;
    public void Buy()
    {
        string name = this.transform.parent.gameObject.name;
        Debug.Log(name);
        Item item = Resources.Load<Item>("Item/" + name);
        Debug.Log(item.itemPrice);
        price = item.itemPrice;
        if (SaveManger.Instance.catFood - price >= 0)
        {
            SaveManger.Instance.catFood -= price;
            SaveManger.Instance.itemHeld[item.itemID] += 1;
            item.itemHeld = SaveManger.Instance.itemHeld[item.itemID] += 1; ;
        }

    }   
}
