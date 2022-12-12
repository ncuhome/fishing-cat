using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpen : MonoBehaviour
{
    //背包引用
    public GameObject Bag;
    bool isOpen;

    public void openBag()
    {
        //控制Bag显示还是隐藏


        isOpen = !isOpen;
        Bag.SetActive(isOpen);

    }

}
