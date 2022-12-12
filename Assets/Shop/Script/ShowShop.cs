using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    public static GameObject lattice;
    public void Update()
    {
        for (int i = 0; i < SaveManger.totalNumberOfItems; i++)
        {
            if (SaveManger.Instance.itemHeld[i] == true)
            {
                int a = i + 1;
                lattice = GameObject.Find("p" + a);
                lattice.transform.Find("δ����").gameObject.SetActive(false);
                lattice.transform.Find("����").gameObject.SetActive(true);
            }
        }
    }
}
