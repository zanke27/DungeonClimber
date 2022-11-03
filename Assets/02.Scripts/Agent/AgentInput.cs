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

    public UnityEvent<Vector2> OnDebugMoveEvent;
    public UnityEvent OnDebugAttackEvent;
    public UnityEvent OnDebugReleaseEvent;

    public bool isDebuging = false;

    private void Update()
    {
        GetMoveEvent();

        if (isDebuging)
            GetDebugEvent();
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


    private void GetDebugEvent()
    {
        GetDebugMoveEvent();
        GetDebugAttackEvent();
        GetDebugReleaseEvent();
    }

    public void GetDebugMoveEvent()
    {
        OnDebugMoveEvent?.Invoke(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }

    public void GetDebugAttackEvent()
    {
        if (Input.GetKey(KeyCode.Space))
            OnDebugAttackEvent?.Invoke();
    }

    public void GetDebugReleaseEvent()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            OnDebugReleaseEvent?.Invoke();
    }
}
