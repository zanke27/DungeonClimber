using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected GameObject _target => targetChecker.Target;
    public GameObject Target => _target;

    private TargetChecker targetChecker;

    private void Awake()
    {
        targetChecker = GameObject.Find("TargetChecker").GetComponent<TargetChecker>();
    }
}
