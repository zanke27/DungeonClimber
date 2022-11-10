using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected GameObject _target => targetChecker.Target;
    public GameObject Target => _target;

    private TargetChecker targetChecker;
    private AgentMove _agentMove;

    public Vector2 MoveDir => _agentMove.MoveDir;

    private void Awake()
    {
        _agentMove = GetComponentInChildren<AgentMove>();
        targetChecker = GetComponentInChildren<TargetChecker>();
    }
}
