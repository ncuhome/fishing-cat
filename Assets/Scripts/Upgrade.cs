using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;


public class Upgrade : MonoBehaviour
{
    public GameObject[] Facilities; //设施
    public Button[] btn;
    public Button ButtonSure;//确认按钮
    public GameObject textUI;//弹出提示的UI
    public Text _text;//提示猫饼数量不足
    public float num;//猫饼的数量
    
    public void Start()
    {
        ButtonSure.onClick.AddListener(btnsure);
        btn[0].onClick.AddListener(btn_0);
        btn[1].onClick.AddListener(btn_1);
        btn[2].onClick.AddListener(btn_2);
        btn[3].onClick.AddListener(btn_3);
        btn[4].onClick.AddListener(btn_4);
        btn[5].onClick.AddListener(btn_5);
    }
    public void btnsure()
    {
        textUI.SetActive(false);
    }
     public void btn_0()
    {
        Facilities[0].SetActive(!Facilities[0].activeSelf);//显示/隐藏升级猫爬架选项
    }
     public void btn_1()
    {
        if(num>=1)
        {
            num--;
            DestroyImmediate(Facilities[0]);
            DestroyImmediate(Facilities[1]);//猫爬架0消失
            Facilities[2].SetActive(true);//猫爬架1出现
        }
        else
        {
            textUI.SetActive(true);
            _text.text="猫饼数量不足！";
            Facilities[0].SetActive(false);
        }
    }
     public void btn_2()
    {
        Facilities[4].SetActive(!Facilities[4].activeSelf);//显示/隐藏升级猫窝选项
    }
    public void btn_3()
    {
        if(num>=1)
        {
            num--;
            DestroyImmediate(Facilities[3]);//低级窝消失
            DestroyImmediate(Facilities[4]);//升级按钮消失
            Facilities[5].SetActive(true);//高级窝出现
        }
        else
        {
            textUI.SetActive(true);
            _text.text="猫饼数量不足！";
            Facilities[4].SetActive(false);
        }
    }
    public void btn_4()
    {
        Facilities[7].SetActive(!Facilities[7].activeSelf);//弹出升级玩具选项
    }
    public void btn_5()
    {
        if(num>=1)
        {
            num--;
            DestroyImmediate(Facilities[6]);//低级玩具消失
            DestroyImmediate(Facilities[7]);//升级按钮消失
            Facilities[8].SetActive(true);//高级玩具出现
        }
        else
        {
            textUI.SetActive(true);
            _text.text="猫饼数量不足！";
            Facilities[7].SetActive(false);
        }
    }


    // Update is called once per frame
    
}
