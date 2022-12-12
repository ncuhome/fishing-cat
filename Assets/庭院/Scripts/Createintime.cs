using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Createintime : MonoBehaviour
{
    /*
     * Introduction：
           * Creator： Xiaohei Wang
         */
    static public float DelayTime;

    [Header("猫饼")]
    [SerializeField]
    private GameObject MaoBing;

    // Start is called before the first frame update
    void Start()
    {
        DelayTime = Time.time;
        MaoBing.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time-DelayTime >=5 && MaoBing.activeInHierarchy==false)
        {
            Debug.Log("生成猫饼");
            MaoBing.SetActive(true);
        }
    }
}
