using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalAudioManager : MonoBehaviour
{
    #region Singleton

    public static GlobalAudioManager instance;

    private void Awake()
    {
        instance = this;
        if (audioManager == null)
        {
            audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        }
    }

    #endregion;

    public AudioManager audioManager;
}
