using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static bool isDontDestroy = false;
    void Awake()
    {
        if (!isDontDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        isDontDestroy = true;
    }
}
