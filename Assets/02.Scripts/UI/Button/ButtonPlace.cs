using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonPlace : MonoBehaviour, IButtonPlace, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private bool _isTouch = false;

    protected bool IsTouch 
    {
        get => _isTouch;
        set => _isTouch = value;
    }

    public UnityEvent OnButtonClickEvent;
    public UnityEvent OnButtonClickingEvent;
    public UnityEvent OnButtonReleaseEvent;

    public virtual void TouchStartEvent()
    {
        IsTouch = true;
        OnButtonClickEvent?.Invoke();
    }

    public virtual void TouchEndEvent()
    {
        if (!IsTouch) return; 
        IsTouch = false;
        OnButtonReleaseEvent?.Invoke();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        TouchStartEvent();
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        TouchEndEvent();
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        TouchEndEvent();
    }

    protected virtual void Update()
    {
        if (!IsTouch) return;
        OnButtonClickingEvent?.Invoke();
    }
}
