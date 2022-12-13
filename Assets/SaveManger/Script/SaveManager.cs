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
   �����ǻᷢ���ĸı���� (�����)
   */
    public int catNum = 1;

    public int cat_inYard_Num;

    public List<CatInfo> catList = new List<CatInfo>();

    public int catFood = 2;

    public int fishingRodNumber = 7;

    public int[] itemPrice = new int[totalNumberOfItems];   //��Ʒ��ӵ������
    public bool[] itemHeld = new bool[totalNumberOfItems];
    public string[] itemName = new string[totalNumberOfItems];
    public string[] itemIntroduction = new string[totalNumberOfItems];

    public int fishingSceneIndex; //��è������0��ʾ�ڲ�ԭ��1��ʾ��ncu��2��ʾ��

    public bool showNcu_blue = false;
    public bool showRoom_pink = false;
    public bool showWood1 = false;
    public bool showWood2 = false;
    public bool showToy1 = false;
    public bool showToy2 = false;
    public bool showCactus1 = false;
    public bool showCactus2 = false;

    public bool canChooseProp = true; //�����ڱ��� use ����
    public bool canChooseFacility = true; //�����ڱ��� use ��ʩ
    public bool canChooseObject = false; //�����ڱ��� use ����

    /*
    �����ǲ��ᷢ���ĸı���� (������)
    */



    /*
   ������������һЩ����
   */
    public SaveManager saveManager;  //�洢���ݵĶ���(saveMangerԤ����)
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

    private void Start()  //���õ���
    {
        if (catNum == 0)
        {
            int R = Random.Range(1, 255);
            int G = Random.Range(1, 255);
            int B = Random.Range(1, 255);
            CatInfo gift;
            gift.catName = "è��";
            gift.r = R;
            gift.g = G;
            gift.b = B;
        }
        // saveManager = Instance;
        for (int i = 0; i < totalNumberOfItems; i++)
        {
            itemPrice[i] = 1;
            itemHeld[i] = false;
        }
    }

    public void SaveGame()  //�洢���ݺ���
    {
        Debug.Log("���ݴ�����" + Application.persistentDataPath);  //������ݵĴ���λ��
        if(!Directory.Exists(Application.dataPath + "/game_SaveDate"))  //���û���ҵ����ݴ洢�ļ��ʹ���һ��
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/game_SaveDate");
        }
        BinaryFormatter formatter = new BinaryFormatter();  //�����Ʊ���
        FileStream file = File.Create(Application.persistentDataPath + "/game_SaveDate/save.txt"); //�ļ�
        var json = JsonUtility.ToJson(saveManager);  //��Ҫ�洢�ı���ת��Ϊjson
        formatter.Serialize(file, json);  //��jsonתΪ�����ƴ����ļ�
        file.Close();  //�����޸�
    }
    public void LoadGame()  //��ȡ���ݺ���
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