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
        if (GlobalSaveManager.instance.saveManager.itemHeld[buyId - 1] == false)
        {
            GlobalSaveManager.instance.saveManager.catFood -= GlobalSaveManager.instance.saveManager.itemPrice[buyId - 1];
            GlobalSaveManager.instance.saveManager.itemHeld[buyId - 1] = true;
            sign.text = "锟姐购锟斤拷锟斤拷" + GlobalSaveManager.instance.saveManager.itemName[buyId - 1];
            sign.gameObject.SetActive(true);
            Invoke("Wait", 1.5f);
        }
      
    }   
    private void Wait()
    { 
        sign.gameObject.SetActive(false);
    }
}
