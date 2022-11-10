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
    #region 공격 관련

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

    // AttackAction에 Attack이라는 함수를 넣을 건데 바꿀필요가 있다면 이 함수를 바꿔서 Attack을 넣게
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
