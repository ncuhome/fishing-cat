﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEditor;
using Unity.VisualScripting;

public class SaveManger : MonoBehaviour
{
    /*
   下面是会发生的改变的量 (活变量)
   */
    public int catNum = 1;
    public int cat_inYard_Num;
    public int R;
    public int G;
    public int B;

    public int[,] catColor = new int[,]{          //名字，R,G,B
                { 02,SaveManger.Instance.R,SaveManger.Instance.G,SaveManger.Instance.B }
            };

    public int fishingRodNumber = 0;

    public int[] itemPrice = new int[totalNumberOfItems];   //物品的拥有数量
    public bool[] itemHeld = new bool[totalNumberOfItems];
    public string[] itemName = new string[totalNumberOfItems];
    public string[] itemIntroduction = new string[totalNumberOfItems];

    /*
    下面是不会发生的改变的量 (死变量)
    */



    /*
   下面是其他的一些变量
   */
    public SaveManger saveManger = Instance;  //存储数据的对象(saveManger预制体)
    public static int totalNumberOfItems = 16;
    public int test = 0;           //测试变量


    /*
    下面是函数部分
    */
    public static SaveManger Instance; //设置单例
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
        R = Random.Range(1, 255);
        G = Random.Range(1, 255);
        B = Random.Range(1, 255);

        saveManger = Instance;
        for (int i = 0; i < totalNumberOfItems; i++)
        {
            itemPrice[i] = 100;
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
        var json = JsonUtility.ToJson(saveManger);  //把要存储的变量转换为json
        formatter.Serialize(file, json);  //把json转为二进制存入文件
        file.Close();  //保存修改
    }
    public void LoadGame()  //读取数据函数
    { 
        BinaryFormatter bf = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "/game_SaveDate/save.txt"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/game_SaveDate/save.txt",FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), saveManger);
            file.Close();
        }
    }
}
