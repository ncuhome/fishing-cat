using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class GlobalVolume : MonoBehaviour
{
    #region Singleton

    public static GlobalVolume instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion;

    public Volume volume;
}
