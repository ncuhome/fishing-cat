using System.Collections;
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
   �����ǻᷢ���ĸı���� (�����)
   */
    public int catFood;

    public int fishingRodNumber = 0;
    public int[] itemHeld = new int[totalNumberOfItems];   //��Ʒ��ӵ������
    /*
    �����ǲ��ᷢ���ĸı���� (������)
    */



    /*
   ������������һЩ����
   */
    public SaveManger saveManger = Instance;  //�洢���ݵĶ���(saveMangerԤ����)
    public static int totalNumberOfItems = 10;
    public int test = 0;           //���Ա���


    /*
    �����Ǻ�������
    */
    public static SaveManger Instance; //���õ���
    private void Awake()  //���õ���
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
    private void Start()  //���õ���
    {
        saveManger = Instance;
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
        var json = JsonUtility.ToJson(saveManger);  //��Ҫ�洢�ı���ת��Ϊjson
        formatter.Serialize(file, json);  //��jsonתΪ�����ƴ����ļ�
        file.Close();  //�����޸�
    }
    public void LoadGame()  //��ȡ���ݺ���
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