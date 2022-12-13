using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectMaoBing : MonoBehaviour
{
    /*
     * Introduction：mavnp
    */
    [Header("猫饼")]
    [SerializeField]
    private GameObject MaoBing;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] col = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (col.Length > 0)
        {
            foreach (Collider2D c in col)
            {
                MaoBing.SetActive(false);
                Createintime.DelayTime = Time.time;
                GlobalSaveManager.instance.saveManager.catFood++;
            }
        }
    }

}
