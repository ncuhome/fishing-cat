using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.UI;

public class BuyThings : MonoBehaviour
{
    public static bool show;
    private int buyId;
    public Text sign;
    private void Start()
    {
        
    }
    public void Buy()
    {
        Debug.Log(1);
        buyId = int.Parse(this.transform.parent.gameObject.name);
        if (SaveManger.Instance.itemHeld[buyId - 1] == false)
        {
            SaveManger.Instance.catFood -= SaveManger.Instance.itemPrice[buyId - 1];
            SaveManger.Instance.itemHeld[buyId - 1] = true;
            sign.text = "你购买了" + SaveManger.Instance.itemName[buyId - 1];
            sign.gameObject.SetActive(true);
            Invoke("Wait", 1.5f);
        }
      
    }   
    private void Wait()
    { 
        sign.gameObject.SetActive(false);
    }
}
