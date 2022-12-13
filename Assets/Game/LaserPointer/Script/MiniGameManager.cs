using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MiniGameManager : MonoBehaviour
{
    public SpriteRenderer background;
    public Sprite grass;
    public Sprite ncu;
    public Sprite room;

    private void Start()
    {
        Debug.Log(GlobalSaveManager.instance.saveManager.fishingSceneIndex);
        switch (GlobalSaveManager.instance.saveManager.fishingSceneIndex)
        {
            case 0:
                background.sprite = grass;
                break;
            case 1:
                background.sprite = ncu;
                break;
            case 2:
                background.sprite = room;
                break;
        }    
    }
}
