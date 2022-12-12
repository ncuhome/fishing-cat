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
    public static bool laserPointer = false;  //������Ƿ���
    public static bool jump = false;
    private float waitTime = 0;
    public static float needTime;
    Animator animator;
    public static int feeling = 100;  //����ֵ
    public static int stamina = 100;  //����ֵ
    public static bool beCaught = false; //è���Ƿ��ܱ�ץ�� 
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
        tili = GameObject.Find("�����ľ�");
        tili.SetActive(false);
        image = GameObject.Find("StrengthѪ��").GetComponent<Image>();
        image1 = GameObject.Find("FeelingѪ��").GetComponent<Image>();
    }

    void Update()
    {
        if (math.abs(rb.velocity.y) > 0.1f)
        {
            jump = true;
            animator.SetBool("jump", true);
        }
        else if (math.abs(rb.velocity.y) <= 0.1f && this.transform.localPosition.y < 0 )  //���
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
            Debug.Log("è�䱻ץ����");
            popAnimation.ShowShopOnClick();
        }
    }
    public void Dropblood(int everyChange)
    {
        //�ж��Ƿ�ʼ����
        if (isPlay)
        {
            //ʹtimer����ʱ������
            timer += Time.deltaTime;
            Jindu -= (Time.deltaTime / duration) * everyChange / 100;
            //�޸�FillAmount��ֵ
            //��ʹ��ǰʱ��ռȫ��ʱ��ı���ΪFillAmount��0��1֮���ֵ��
            image.fillAmount = Mathf.Lerp(0, 1, Jindu);

            //��ʱ��
            if (timer >= duration)
            {
                //ֹͣ����
                isPlay = false;
                //��timer��ԭΪ0��Ϊ��һ�μ�ʱ��׼��
                timer = 0;
            }
        }

    }
    public void DropFeeling(int everyChange)
    {
        //�ж��Ƿ�ʼ����
        if (isPlay1)
        {
            //ʹtimer����ʱ������
            timer1 += Time.deltaTime;
            Jindu1 -= (Time.deltaTime / duration) * everyChange / 100;
            //�޸�FillAmount��ֵ
            //��ʹ��ǰʱ��ռȫ��ʱ��ı���ΪFillAmount��0��1֮���ֵ��
            image1.fillAmount = Mathf.Lerp(0, 1, Jindu1);

            //��ʱ��
            if (timer1 >= duration)
            {
                //ֹͣ����
                isPlay1 = false;
                //��timer��ԭΪ0��Ϊ��һ�μ�ʱ��׼��
                timer1 = 0;
            }
        }

    }
}
