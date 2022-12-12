using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvasLoader : MonoBehaviour
{
    public float fadeDuration = 0.5f;

    public Animator anim;
    static bool isDontDestroy = false;

    void Awake()
    {
        if (!isDontDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        isDontDestroy = true;
        // anim = GetComponent<Animator>();
    }

    public void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        if (anim == null) Debug.Log("null");
        anim.SetTrigger("FadeIn");
        // StartCoroutine(Restore(GetClipTime("FadeIn")));
    }
}
