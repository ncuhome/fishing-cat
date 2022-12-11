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
    public static bool show = false;

    IEnumerator ShowShopUI(GameObject UI)
    {
        show = true;
        float time = 0;
        Debug.Log("1");
        while (time <= 1)
        {
            UI.transform.localScale = Vector3.one * showCurve.Evaluate(time);
            time += Time.deltaTime * showSpeed;
            yield return null;
        }
    }

    IEnumerator HideShopUI(GameObject UI)
    {
        float time = 0;
        while (time <= 1)
        {
            UI.transform.localScale = Vector3.one * hideCurve.Evaluate(time);
            time += Time.deltaTime * showSpeed;
            yield return null;
        }
        show = false;
    }
    public void ShowShopOnClick()
    {
        if (!show)
        {
            StartCoroutine(ShowShopUI(shopUI));
        }
    }
    public void HideShopOnClick()
    {
        StartCoroutine(HideShopUI(shopUI));
    }
}

