using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Cat : MonoBehaviour, IPointerDownHandler
{
    int face = -1;
    private Rigidbody2D rb;
    public static bool laserPointer = false;  //激光笔是否开着
    public static bool jump = false;
    private float waitTime = 0;
    public static float needTime;
    Animator animator;
    public static int feeling = 100;  //心情值
    public static int stamina = 100;  //体力值
    public static bool beCaught = false; //猫咪是否能被抓到 
    public static PopAnimation popAnimation;
    public static GameObject tili;
    private Image image;
    private Image image1;
    private float timer = 0;
    private float timer1 = 0;
    private bool isPlay = false;
    public static bool isPlay1 = false;
    private float duration = 1;
    private float Jindu = 1;
    private float Jindu1 = 1;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
        popAnimation = GetComponent<PopAnimation>();
        tili = GameObject.Find("体力耗尽");
        tili.SetActive(false);
        image = GameObject.Find("Strength血条").GetComponent<Image>();
        image1 = GameObject.Find("Feeling血条").GetComponent<Image>();
    }

    void Update()
    {
        if (math.abs(rb.velocity.y) > 0.1f)
        {
            jump = true;
            animator.SetBool("jump", true);
        }
        else if (math.abs(rb.velocity.y) <= 0.1f && this.transform.localPosition.y < 0 )  //落地
        {
            jump = false;
            animator.SetBool("jump", false);
        }
        animator.SetBool("laserPointer", laserPointer);
        if (laserPointer && jump == false)
        {
            waitTime += Time.deltaTime;
            if(waitTime > needTime)
            {
                CatJump();
                waitTime = 0;
            }
        }
        else if (!laserPointer)
        {
            waitTime = 0;
        }
        Dropblood(20);
        DropFeeling(35);
    }
    public void CatJump()
    {
        rb.velocity = new Vector3(-0.6f * face, 10, 0);
        face *= -1;
        this.transform.localScale = new Vector3(-face, 1, 1);
        stamina -= 20;
        isPlay = true;
        if (stamina <= 0)
        {
            stamina = 0;
            beCaught = true;
            tili.SetActive(true);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(stamina);
        if (Cat.beCaught)
        {
            Debug.Log("猫咪被抓到了");
            popAnimation.ShowShopOnClick();
        }
    }
    public void Dropblood(int everyChange)
    {
        //判断是否开始读条
        if (isPlay)
        {
            //使timer根据时间增长
            timer += Time.deltaTime;
            Jindu -= (Time.deltaTime / duration) * everyChange / 100;
            //修改FillAmount的值
            //（使当前时间占全部时间的比例为FillAmount中0到1之间的值）
            image.fillAmount = Mathf.Lerp(0, 1, Jindu);

            //计时器
            if (timer >= duration)
            {
                //停止读条
                isPlay = false;
                //将timer还原为0，为下一次计时做准备
                timer = 0;
            }
        }

    }
    public void DropFeeling(int everyChange)
    {
        //判断是否开始读条
        if (isPlay1)
        {
            //使timer根据时间增长
            timer1 += Time.deltaTime;
            Jindu1 -= (Time.deltaTime / duration) * everyChange / 100;
            //修改FillAmount的值
            //（使当前时间占全部时间的比例为FillAmount中0到1之间的值）
            image1.fillAmount = Mathf.Lerp(0, 1, Jindu1);

            //计时器
            if (timer1 >= duration)
            {
                //停止读条
                isPlay1 = false;
                //将timer还原为0，为下一次计时做准备
                timer1 = 0;
            }
        }

    }
}
