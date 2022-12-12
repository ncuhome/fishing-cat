using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LaserPointerButton : MonoBehaviour
{
    public GameObject light;
    public GameObject prompt;
    public static PopAnimation pop;
    public GameObject self;
    private void Start()
    {
        pop = GetComponent<PopAnimation>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        prompt.SetActive(true);
        Invoke("Prompt", 3f);
        Cat.feeling -= 35;
        if (Cat.feeling <= 0)
        {
            Debug.Log(1);
            pop.ShowShopOnClick();
            self.SetActive(false);
        }
        Cat.isPlay1 = true;
    }
    public void Update()
    {
        if(Cat.popAnimation.show == true)
        {
            self.SetActive(false);
        }
        
        //if (popAnimation.show == true)
        //{
        //    gameObject.SetActive(false);
        //}
    }
    public void OnClick()
    {
        if(Cat.laserPointer == true)
        {
            Cat.laserPointer = false;
            light.gameObject.SetActive(false);
        }
        else if (Cat.laserPointer == false)
        {
            Cat.laserPointer = true;
            light.gameObject.SetActive(true);
        }
        Cat.needTime = UnityEngine.Random.Range(10f, 50f) / 10;
    }
    private void Prompt()
    {
        prompt.SetActive(false);
    }
}
