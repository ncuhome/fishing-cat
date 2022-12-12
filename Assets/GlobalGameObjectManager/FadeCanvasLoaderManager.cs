using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvasLoaderManager : MonoBehaviour
{
    #region Singleton

    public static FadeCanvasLoaderManager instance;

    private void Awake()
    {
        instance = this;
        if (fadeCanvasLoader == null)
        {
            fadeCanvasLoader = GameObject.FindGameObjectWithTag("FadeCanvas").GetComponent<FadeCanvasLoader>();
        }
    }

    #endregion;

    public FadeCanvasLoader fadeCanvasLoader;
}
