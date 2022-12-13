using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MapManager : MonoBehaviour
{
    public Image ncu_blue;
    public Image room_pink;
    public Image wood1;
    public Image wood2;
    public Image toy1;
    public Image toy2;
    public Image cactus1;
    public Image cactus2;

    public Button yardButton;
    public Button grassButton;
    public Button ncuButton;
    public Button roomButton;

    public TMP_Text catFoodNum;
    public TMP_Text fishingRodNumber;

    private void Update()
    {
        catFoodNum.text = "猫饼：" + GlobalSaveManager.instance.saveManager.catFood;   
        fishingRodNumber.text = "钓竿：" + GlobalSaveManager.instance.saveManager.fishingRodNumber; 

        ChangeVisable(ncu_blue, GlobalSaveManager.instance.saveManager.showNcu_blue);
        ChangeVisable(room_pink, GlobalSaveManager.instance.saveManager.showRoom_pink);
        ChangeVisable(wood1, GlobalSaveManager.instance.saveManager.showWood1);
        ChangeVisable(wood2, GlobalSaveManager.instance.saveManager.showWood2);
        ChangeVisable(toy1, GlobalSaveManager.instance.saveManager.showToy1);
        ChangeVisable(toy2, GlobalSaveManager.instance.saveManager.showToy2);
        ChangeVisable(cactus1, GlobalSaveManager.instance.saveManager.showCactus1);
        ChangeVisable(cactus2, GlobalSaveManager.instance.saveManager.showCactus2);
    }

    private void Start()
    {
        yardButton.onClick.AddListener(() => LoadScene(1));
        grassButton.onClick.AddListener(() => LoadGrassScene(2));
        ncuButton.onClick.AddListener(() => LoadNcuScene(2));
        roomButton.onClick.AddListener(() => LoadRoomScene(2));
        // FadeCanvasLoaderManager.instance.fadeCanvasLoader.FadeIn();
    }

    void ChangeVisable(Image image, bool show)
    {
        Color c = image.color;
        if (show)
        {
            c.a = 1;
        }
        else
        {
            c.a = 0;
        }
        image.color = c;
    }

    void LoadScene(int index)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    void LoadGrassScene(int index)
    {
        GlobalSaveManager.instance.saveManager.fishingSceneIndex = 0;
        GlobalSaveManager.instance.saveManager.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    void LoadNcuScene(int index)
    {
        GlobalSaveManager.instance.saveManager.fishingSceneIndex = 1;
        GlobalSaveManager.instance.saveManager.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }

    void LoadRoomScene(int index)
    {
        GlobalSaveManager.instance.saveManager.fishingSceneIndex = 2;
        GlobalSaveManager.instance.saveManager.SaveGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
