using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowShop : MonoBehaviour
{
    private static int storePages = 0;      //������ʾ���̵�ҳ��
    private static int totalPages = 3;          //�̵����ҳ��
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
