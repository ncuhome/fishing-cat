using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeDate : MonoBehaviour
{
    private TMP_Text catFood;
    private TMP_Text fishingRodNumber;
    private void Start()
    {
        catFood = GameObject.Find("CatFoodText").GetComponent<TMP_Text>();
        fishingRodNumber = GameObject.Find("FishingRodNumberText").GetComponent<TMP_Text>(); ;
    }
    private void Update()
    {
        catFood.text = "Ã¨±ý:" + GlobalSaveManager.instance.saveManager.catFood;
        fishingRodNumber.text = "µö¸Í:" + GlobalSaveManager.instance.saveManager.fishingRodNumber +"/7";
    }


}
