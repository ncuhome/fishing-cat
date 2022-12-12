using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NumberText : MonoBehaviour
{
    private Text numberText;
    public GameObject UpgradeManager;
    // Start is called before the first frame update
    void Start()
    {
        numberText =GetComponent<Text>();
        UpgradeManager =GameObject.Find("UpgradeManager");
    }

    // Update is called once per frame
    void Update()
    {
        numberText.text=UpgradeManager.GetComponent<Upgrade>().num.ToString();
    }
}
