using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCat : MonoBehaviour
{
    /*
     * Introduction：mavnp
    */

    // Start is called before the first frame update

    static public int i, CatNum;
    void Start()
    {
        CatNum = GlobalSaveManager.instance.saveManager.catNum;
    }

    // Update is called once per frame
    void Update()
    {
        if (CatNum > 0) 
        {
            for (i = -1; CatNum > 0; CatNum--)
            {
                GameObject newClone = (GameObject)Instantiate(Resources.Load("Prefabs/Cat"), new Vector3(Random.Range(100, 1000), Random.Range(400, 1100), 0), Quaternion.Euler(new Vector3(0, 0, 0f)));
                newClone.transform.name = GlobalSaveManager.instance.saveManager.catList[++i].catName;//赋予预制体在场景中的名字
            }
        }
    }
}
