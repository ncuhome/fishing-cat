using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyThings : MonoBehaviour
{
    public static bool show;
    private static int buyId;
    public Text sign;
    public GameObject decideBuyUI;
    public Text itemName;
    public Text itemIntroduction;

    //不 find 了，记得手动录入
    private void Start()
    {
        decideBuyUI = GameObject.Find("确认购买");
        itemName = GameObject.Find("物品名称").GetComponent<Text>();
        itemIntroduction = GameObject.Find("物品描述").GetComponent<Text>();
    }
    public void ShowBuy()
    {
        Debug.Log(1);
        buyId = int.Parse(this.transform.parent.gameObject.name);
        decideBuyUI.transform.localScale = Vector3.one;
        itemName.text = GlobalSaveManager.instance.saveManager.itemName[buyId];
        itemIntroduction.text = GlobalSaveManager.instance.saveManager.itemIntroduction[buyId];
    }
    public void Buy()
    {
        if (GlobalSaveManager.instance.saveManager.itemHeld[buyId - 1] == false && GlobalSaveManager.instance.saveManager.catFood > 0)
        {
            GlobalSaveManager.instance.saveManager.catFood -= GlobalSaveManager.instance.saveManager.itemPrice[buyId - 1];
            GlobalSaveManager.instance.saveManager.itemHeld[buyId - 1] = true;
            sign.text = "你购买了" + GlobalSaveManager.instance.saveManager.itemName[buyId - 1];
            sign.gameObject.SetActive(true);
            Invoke("Wait", 1.5f);
        }
        else
        {
            sign.text = "购买失败";
            sign.gameObject.SetActive(true);
            Invoke("Wait", 1.5f);
        }
    }
    private void Wait()
    { 
        sign.gameObject.SetActive(false);
    }
    public void back()
    {
        decideBuyUI.transform.localScale = new Vector3(0,0,0);
    }
}
