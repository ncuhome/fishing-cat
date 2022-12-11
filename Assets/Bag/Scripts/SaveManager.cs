using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SaveManager : MonoBehaviour
{
    /*
   下面是会发生的改变的量
   */

    public Inventory Bag;
    public Item sword;
    public Item shoes;
    public Item armor;
    public int[] itemHelds = new int[10];
    /*
   下面是不会发生的改变的量
   */


    /*
   下面是其他的一些变量
   */
    public SaveManager saveManager = Instance;  //存储数据的对象(saveManger预制体)
    public int test = 0;           //测试变量


    /*
    下面是函数部分
    */
    public static SaveManager Instance; //设置单例
    private void Awake()  //设置单例
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()  //设置单例
    {
        saveManager = Instance;
        int BagSize = Bag.itemList.Count;
        int swordHeld = sword.itemHeld;
        int shoesHeld = shoes.itemHeld;
        int armorHeld = armor.itemHeld;
        itemHelds[0] = swordHeld;
        itemHelds[1] = shoesHeld;
        itemHelds[2] = armorHeld;


    }
    public void SaveGame()  //存储数据函数
    {
        Debug.Log("数据储存在" + Application.persistentDataPath);  //输出数据的储存位置
        if (!Directory.Exists(Application.dataPath + "/game_SaveDate"))  //如果没有找到数据存储文件就创建一个
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
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveDate/save.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), saveManager);
            file.Close();
        }
    }



}
