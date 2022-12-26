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
    public static GameObject shopPanal;

    private void Start()
    {
        shopPanal = GameObject.Find("shopPanal");
    }
    IEnumerator ShowShopUI(GameObject UI)
    {
        shopPanal.transform.localScale = Vector3.one;
        BuyThings.show = true;
        float time = 0;
        Debug.Log("1");
        while (time <= 1.1f)
        {
            UI.transform.localScale = Vector3.one *  showCurve.Evaluate(time);
            time += Time.deltaTime * showSpeed;
            yield return null;
        }
    }

    IEnumerator HideShopUI(GameObject UI)
    {
        shopPanal.transform.localScale = new Vector3(0, 0, 0);
        float time = 0;
        while (time <= 1.1f)
        {
            UI.transform.localScale = Vector3.one *  hideCurve.Evaluate(time);
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

