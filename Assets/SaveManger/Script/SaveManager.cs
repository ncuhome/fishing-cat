using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;

public struct CatInfo
{
    public string catName;
    public int r;
    public int g;
    public int b;
}

public class SaveManager : MonoBehaviour
{
    /*
   下面是会发生的改变的量 (活变量)
   */
    public int catNum = 0;
    public int cat_inYard_Num;

    //第一只猫
    public CatInfo cat1;
    //其它猫颜色
    public List<CatInfo> catList = new List<CatInfo>();

    public int catFood = 2;
    public int fishingRodNumber = 7;

    public int[] itemPrice = new int[totalNumberOfItems];   //物品的拥有数量
    public bool[] itemHeld = new bool[totalNumberOfItems];
    public string[] itemName = new string[totalNumberOfItems];
    public string[] itemIntroduction = new string[totalNumberOfItems];

    public int fishingSceneIndex; //钓猫背景，0表示在草原，1表示在ncu，2表示在

    public bool showNcu_blue = false;
    public bool showRoom_pink = false;
    public bool showWood1 = false;
    public bool showWood2 = false;
    public bool showToy1 = false;
    public bool showToy2 = false;
    public bool showCactus1 = false;
    public bool showCactus2 = false;

    public bool canChooseProp = true; //可以在背包 use 道具
    public bool canChooseFacility = true; //可以在背包 use 设施
    public bool canChooseObject = false; //可以在背包 use 物体

    /*
    下面是不会发生的改变的量 (死变量)
    */



    /*
   下面是其他的一些变量
   */
    static bool isDontDestroy = false;
    public SaveManager saveManager;  //存储数据的对象(saveManger预制体)
    public static int totalNumberOfItems = 16;


    // public static SaveManager Instance;
    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(this);
    //     }
    //     else
    //     {
    //         Destroy(this);
    //     }
    // }

    void Awake()
    {
        if (!isDontDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        isDontDestroy = true;
        // anim = GetComponent<Animator>();
    }

    private void Start()  //设置单例
    {
        if (catNum == 0)
        {
            CatInfo catInfo;
            catInfo.catName = "gift";
            catInfo.r = Random.Range(1, 255);
            catInfo.g = Random.Range(1, 255);
            catInfo.b = Random.Range(1, 255);
            catList.Add(catInfo);
            SaveGame();
            catNum++;
        }

        // saveManager = Instance;
        for (int i = 0; i < totalNumberOfItems; i++)
        {
            itemPrice[i] = 1;
            itemHeld[i] = false;
        }
    }

    public void SaveGame()  //存储数据函数
    {
        Debug.Log("数据储存在" + Application.persistentDataPath);  //输出数据的储存位置
        if(!Directory.Exists(Application.dataPath + "/game_SaveDate"))  //如果没有找到数据存储文件就创建一个
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveDate");
        }
        BinaryFormatter formatter = new BinaryFormatter();  //二进制变量
        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveDate/save.txt"); //文件
        var json = JsonUtility.ToJson(saveManager);  //把要存储的变量转换为json
        formatter.Serialize(file, json);  //把json转为二进制存入文件
        file.Close();  //保存修改
    }
    public void LoadGame()  //读取数据函数
    { 
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveDate/save.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveDate/save.txt",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), saveManager);
            file.Close();
        }
    }
}