using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Sword,
    Gun
}

public abstract class Weapon : MonoBehaviour
{
    #region ���� ����

    [SerializeField] protected bool _delayCoroutine = false;

    [SerializeField]
    protected bool _isShooting = false;

    [SerializeField]
    protected bool isCorStop = false;

    protected float chargeTime = 0f;
    #endregion

    public WeaponType weaponType;

    protected Action AttackAction;

    protected virtual void Awake()
    {
        AttackActionInit();
    }

    // AttackAction�� Attack�̶�� �Լ��� ���� �ǵ� �ٲ��ʿ䰡 �ִٸ� �� �Լ��� �ٲ㼭 Attack�� �ְ�
    protected virtual void AttackActionInit()
    {
        AttackAction -= Attack;
        AttackAction += Attack;
    }

    public abstract void Attack();

    public void TryShooting()
    {
        _isShooting = true;
        AttackAction();
        //OnAttack?.Invoke();
    }

    public void StopShooting()
    {
        _isShooting = false;
    }
}
