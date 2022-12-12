using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSaveManager : MonoBehaviour
{
    #region Singleton

    public static GlobalSaveManager instance;

    private void Awake()
    {
        instance = this;
        //空的才需要填充，记得填充一下就无需这个（但大部分是不销毁对象，无法提前填充）
        if (saveManager == null)
        {
            saveManager = GameObject.FindGameObjectWithTag("SaveManager").GetComponent<SaveManager>();
        }
    }

    #endregion;

    public SaveManager saveManager;
}
