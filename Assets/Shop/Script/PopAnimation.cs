using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopAnimation : MonoBehaviour
{
    public AnimationCurve showCurve;
    public AnimationCurve hideCurve;
    public float showSpeed = 3f;
    public GameObject shopUI;
    public bool show;

    public float maxTime = 1.2f; //最大放大倍数

    IEnumerator ShowShopUI(GameObject UI)
    {
        BuyThings.show = true;
        float time = 0;
        Debug.Log("1");
        while (time <= 1.1f)
        {
            UI.transform.localScale = Vector3.one * maxTime * showCurve.Evaluate(time);
            time += Time.deltaTime * showSpeed;
            yield return null;
        }
    }

    IEnumerator HideShopUI(GameObject UI)
    {
        float time = 0;
        while (time <= 1.1f)
        {
            UI.transform.localScale = Vector3.one * maxTime * hideCurve.Evaluate(time);
            time += Time.deltaTime * showSpeed;
            yield return null;
        }
        BuyThings.show = false;
    }
    public void ShowShopOnClick()
    {
        if (!BuyThings.show)
        {
            StartCoroutine(ShowShopUI(shopUI));
        }
        Debug.Log(BuyThings.show);
    }
    public void HideShopOnClick()
    {
        StartCoroutine(HideShopUI(shopUI));
        Debug.Log(BuyThings.show);
    }
}

