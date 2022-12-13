using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCat : MonoBehaviour
{
    /*
     * Introduction：mavnp
    */

    // Start is called before the first frame update

    private int i, CatNum;
    void Start()
    {
        CatNum = GlobalSaveManager.instance.saveManager.catNum;
    }

    // Update is called once per frame
    void Update()
    {
        for (i=0; GlobalSaveManager.instance.saveManager.catNum > 0; GlobalSaveManager.instance.saveManager.catNum--,i++)
        {
            GameObject newClone = (GameObject)Instantiate(Resources.Load("Prefabs/Cat"), new Vector3(Random.Range(100, 1000), Random.Range(400, 1100), 0), Quaternion.Euler(new Vector3(0, 0, 0f)));
            newClone.name = GlobalSaveManager.instance.saveManager.catList[i].catName;//赋予预制体在场景中的名字
            newClone.GetComponent<SpriteRenderer>().color = new Color(GlobalSaveManager.instance.saveManager.catList[i].r / 255f, GlobalSaveManager.instance.saveManager.catList[i].g / 255f, GlobalSaveManager.instance.saveManager.catList[i].b / 255f, 1);
        }
    }
}
