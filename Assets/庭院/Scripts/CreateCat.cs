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
        CatNum = SaveManger.Instance.catNum;
    }

    // Update is called once per frame
    void Update()
    {
        for (i=0; SaveManger.Instance.catNum > 0; SaveManger.Instance.catNum--,i++)
        {
            GameObject newClone = (GameObject)Instantiate(Resources.Load("Prefabs/Cat"), new Vector3(Random.Range(100, 1000), Random.Range(400, 1100), 0), Quaternion.Euler(new Vector3(0, 0, 0f)));
            newClone.name = SaveManger.Instance.catColor[i,0].ToString();//赋予预制体在场景中的名字
            newClone.GetComponent<SpriteRenderer>().color = new Color(SaveManger.Instance.catColor[i, 1] / 255f, SaveManger.Instance.catColor[i, 2] / 255f, SaveManger.Instance.catColor[i, 3] / 255f, 1);
        }
    }
}
