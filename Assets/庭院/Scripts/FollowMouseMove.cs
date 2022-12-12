using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseMove : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 获得鼠标当前位置的 X 和 Y
        float mouseX = Input.GetAxis("Mouse X") * moveSpeed ;

        if (297.5 > this.transform.localPosition.x + mouseX )
        {
            this.transform.position=new Vector3((float)297.5,this.transform.position.y,this.transform.position.z);
            return;
        }
        if(this.transform.localPosition.x > 872.5)
        {
            this.transform.position = new Vector3((float)872.5, this.transform.position.y, this.transform.position.z);
            return;
        }
        this.transform.Translate(new Vector3(mouseX, 0, 0));
        // 鼠标在 X 轴上的移动转为主角左右的移动，同时带动其子物体摄像机的左右移动

    }
}
