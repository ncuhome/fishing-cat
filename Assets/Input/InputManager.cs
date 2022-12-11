using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(UnityEngine.UI.AspectRatioFitter))]
public class InputManager
    : MonoBehaviour,
        IDragHandler,
        IEndDragHandler,
        IPointerDownHandler,
        IPointerUpHandler
{
    [Header("Input Values")]
    public bool dragging = false;
    public float horizontal = 0;
    public float maxRadiu; //最大拖拽半径
    // public float fadeSpeed; //线性衰减比例（太慢将停止）

    private float pointX;
    private Vector2 backgroundPos;

    public void OnDrag(PointerEventData eventData)
    {
        dragging = true;

        Vector2 pointerWorldPos = ScreenToWorldPoint(eventData.position);
        pointX = (pointerWorldPos.x - backgroundPos.x) / (maxRadiu / 2);
        //避免超出最大拖拽距离
        if (pointX > 1) { pointX = 1.0f; }
        if (pointX < -1) { pointX = -1.0f; }

        float vecX = pointerWorldPos.x - backgroundPos.x;
        backgroundPos.x += (maxRadiu > vecX) ? vecX : maxRadiu;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        pointX = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundPos = ScreenToWorldPoint(eventData.position);
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnEndDrag(eventData);
    }

    void Update()
    {
        horizontal = pointX;
    }

    /// <summary>
    /// 将屏幕坐标转换成世界坐标
    /// </summary>>
    /// <param name = "pos"></param>
    /// <returns></returns>
    public Vector2 ScreenToWorldPoint(Vector3 pos)
    {
        return Camera.main.ScreenToWorldPoint(pos);
    }
}
