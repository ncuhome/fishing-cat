using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FishingManager : MonoBehaviour
{
    public Image background;
    public Sprite grass;
    public Sprite ncu;
    public Sprite room;

    public Button startBtn;

    private void Start()
    {
        startBtn.onClick.AddListener(() => LoadGameScene());
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

    void LoadGameScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
