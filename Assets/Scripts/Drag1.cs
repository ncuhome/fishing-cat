using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag1 : MonoBehaviour
{
    Vector2 first;
    Vector2 second;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (Event.current.type == EventType.MouseDown)
            {//记录鼠标按下的位置  
                first = Event.current.mousePosition;
            }
            if (Event.current.type == EventType.MouseDrag)
            {//记录鼠标拖动的位置  
                second = Event.current.mousePosition;
                if (second.x < first.x)
                {//拖动的位置的 x 坐标比按下的位置的 x 坐标小时,响应向左事件  
                    print("left");
                }
                if (second.x > first.x)
                {//拖动的位置的 x 坐标比按下的位置的 x 坐标大时,响应向右事件  
                    print("right");
            }

            
            float tempX = first.x - second.x;


                //控制地图不移出屏幕
                if (Mathf.Abs(this.transform.position.x + tempX) > 287.5)
                {
                    return;
                }

                this.transform.Translate(new Vector3(tempX, 0, 0));


                first = second;
             }
    }
}
