using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;

    [SerializeField]
    private RectTransform rectTrm;
    
    [SerializeField,Range(10, 150)]
    private float leverRange = 75;

    public Vector2 inputDir = Vector2.zero;

    private void Awake()
    {
        rectTrm = GetComponent<RectTransform>();
    }

    public void DragEvent(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTrm.anchoredPosition;
        var inputVec = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVec;
        inputDir = inputVec / leverRange;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragEvent(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragEvent(eventData);
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector3.zero;
        inputDir = Vector2.zero;
    }
}
