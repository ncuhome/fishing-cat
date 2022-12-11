using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    private static int storePages = 0;      //现在显示的商店页数
    private static int totalPages = 3;          //商店的总页数
    public GameObject[] Pages = new GameObject[totalPages];


    public void AddStorePages()
    {
        Pages[storePages].SetActive(false);
        storePages++;
        if(storePages > totalPages - 1)
        {
            storePages -= totalPages;
        }
        Pages[storePages].SetActive(true);
    }
    public void CutStorePages()
    {
        Pages[storePages].SetActive(false);
        storePages--;
        if (storePages < 0)
        {
            storePages += totalPages;
        }
        Pages[storePages].SetActive(true);
    }
}
