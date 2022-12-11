using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float maxMoveSpeed; //摄像机最大移动速度
    public Vector2 border; //摄像机移动水平边界

    public InputManager inputManager;

    private float moveSpeed;
    private float camWidth;
    private float camHeight;

    private void Awake()
    {
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }

    void Update()
    {
        Vector3 tPos = new Vector3(0, transform.position.y, transform.position.z);
        tPos.x = Mathf.Clamp(transform.position.x + inputManager.horizontal * maxMoveSpeed, border.x + camWidth, border.y - camWidth);
        Debug.Log(inputManager.horizontal);
        transform.position = tPos;
    }
}
