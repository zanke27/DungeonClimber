using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentInput : MonoBehaviour
{
    [SerializeField]
    private JoyStick joystick = null;

    public UnityEvent<Vector2> OnMoveEvent;
    public UnityEvent OnAttackEvent;

    private void Update()
    {
        GetMoveEvent();
        GetAttackEvent();
    }

    private void GetMoveEvent()
    {
        OnMoveEvent?.Invoke(joystick.inputDir);
    }

    private void GetAttackEvent()
    {

    }
}
