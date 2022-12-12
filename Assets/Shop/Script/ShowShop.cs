using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public static GameObject lattice;
    public void Update()
    {
        for (int i = 0; i < SaveManager.totalNumberOfItems; i++)
        {
            if (GlobalSaveManager.instance.saveManager.itemHeld[i] == true)
            {
                int a = i + 1;
                lattice = GameObject.Find("p" + a);
                lattice.transform.Find("未锟斤拷锟斤拷").gameObject.SetActive(false);
                lattice.transform.Find("锟斤拷锟斤拷").gameObject.SetActive(true);
            }
        }
    }
}
