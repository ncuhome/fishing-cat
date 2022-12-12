using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DongHuaController : MonoBehaviour
{
    [Header("行走动画")]
    [SerializeField]
    private GameObject Cartoon0;

    [Header("睡觉动画")]
    [SerializeField]
    private GameObject Cartoon1;

    [Header("揣爪动画")]
    [SerializeField]
    private GameObject Cartoon2;

    [Header("蹲下动画")]
    [SerializeField]
    private GameObject Cartoon3;

    [Header("趴下动画")]
    [SerializeField]
    private GameObject Cartoon4;

    [Header("玩球动画")]
    [SerializeField]
    private GameObject Cartoon5;

    [Header("洗脸动画")]
    [SerializeField]
    private GameObject Cartoon6;

    [Header("纸箱动画")]
    [SerializeField]
    private GameObject Cartoon7;

    private float delayTime;
    int Rdm;
    int rdm;
    int random;
    int Last_random;

    // Start is called before the first frame update
    void Start()
    {
        Cartoon0.SetActive(true);
        Cartoon1.SetActive(false);
        Cartoon2.SetActive(false);
        Cartoon3.SetActive(false);
        Cartoon4.SetActive(false);
        Cartoon5.SetActive(false);
        Cartoon6.SetActive(false);
        Cartoon7.SetActive(false);
        Rdm = Random.Range(4, 7);
        rdm = Random.Range(2, 3);
        delayTime = Time.time;
        Debug.Log("开始");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Caturn"+Cartoon0.activeInHierarchy);
        if (Cartoon0.activeInHierarchy == true && (Time.time - delayTime == Rdm))
        {
            Debug.Log("换动作");
            Rdm = Random.Range(4, 7);
            random = Random.Range(1, 7);
            Cartoon0.SetActive(false);
            switch (random)
            {
                case 1:
                    Cartoon1.SetActive(true);
                    break;
                case 2:
                    Cartoon2.SetActive(true);
                    break;
                case 3:
                    Cartoon3.SetActive(true);
                    break;
                case 4:
                    Cartoon4.SetActive(true);
                    break;
                case 5:
                    Cartoon5.SetActive(true);
                    break;
                case 6:
                    Cartoon6.SetActive(true);
                    break;
                case 7:
                    Cartoon7.SetActive(true);
                    break;
            }
            Last_random = random;
            delayTime = Time.time;
        }

        if (Cartoon0.activeInHierarchy== false && (Time.time - delayTime == rdm))
        {
            Debug.Log("开始行走");
            rdm = Random.Range(2, 3);
            random = Random.Range(1, 7);
            switch(Last_random)
            {
                case 1:
                    Cartoon1.SetActive(false);
                    break;
                case 2:
                    Cartoon2.SetActive(false);
                    break;
                case 3:
                    Cartoon3.SetActive(false);
                    break;
                case 4:
                    Cartoon4.SetActive(false);
                    break;
                case 5:
                    Cartoon5.SetActive(false);
                    break;
                case 6:
                    Cartoon6.SetActive(false);
                    break;
                case 7:
                    Cartoon7.SetActive(false);
                    break;
            }
            switch (random)
            {
                case 1:
                    Cartoon0.SetActive(true);
                    break;
                case 2:
                    Cartoon2.SetActive(true);
                    break;
                case 3:
                    Cartoon3.SetActive(true);
                    break;
                case 4:
                    Cartoon4.SetActive(true);
                    break;
                case 5:
                    Cartoon5.SetActive(true);
                    break;
                case 6:
                    Cartoon6.SetActive(true);
                    break;
                case 7:
                    Cartoon7.SetActive(true);
                    break;

            }
            delayTime = Time.time;
        }
    }


}
