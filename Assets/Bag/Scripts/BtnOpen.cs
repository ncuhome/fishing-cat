using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpen : MonoBehaviour
{
    //��������
    public GameObject Bag;
    bool isOpen;

    public void openBag()
    {
        //����Bag��ʾ��������


        isOpen = !isOpen;
        Bag.SetActive(isOpen);

    }

}
