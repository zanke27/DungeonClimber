using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    [SerializeField]
    private VariableJoystick joystick = null;

    public UnityEvent<Vector2> OnMoveEvent;
    public UnityEvent OnAttackEvent;
    public UnityEvent OnAttackReleaseEvent;

    private void Update()
    {
        GetMoveEvent();
    }

    private void GetMoveEvent()
    {
        OnMoveEvent?.Invoke(joystick.Direction);
    }

    public void GetAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
    public void GetAttackReleaseEvent()
    {
        OnAttackReleaseEvent?.Invoke();
    }
}
