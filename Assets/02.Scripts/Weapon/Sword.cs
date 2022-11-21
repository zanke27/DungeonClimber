using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using DG.Tweening;

public class Sword : Weapon
{
    [SerializeField]
    protected SwordDataSO _swordDataSO;

    protected Vector2 targetDir;

    public float speed1 = 0.1f;
    public float speed2 = 0.1f;

    protected override void Awake()
    {
        base.Awake();
        weaponType = WeaponType.Sword;
    }

    public override void Attack()
    {
        if (_isShooting && _delayCoroutine == false)
        {
            SwordAttack();
            StartCoroutine(DelayNextShootCoroutine());
        }
    }

    private void SwordAttack()
    {
        if (PlayerTrm.Target != null)
            targetDir = PlayerTrm.Target.transform.position - PlayerTrm.transform.position;
        else
            targetDir = PlayerTrm.MoveDir;

        Sequence seq = DOTween.Sequence();

        seq.Append(transform.DOLocalRotate(new Vector3(0, 0, 80), speed1));
        seq.Append(transform.DOLocalRotate(new Vector3(0, 0, -100), speed2, RotateMode.Fast));
        seq.Append(transform.DOLocalRotate(new Vector3(0, 0, 20), _swordDataSO.attackDelay / 4));
    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        _delayCoroutine = true;
        yield return new WaitForSeconds(_swordDataSO.attackDelay);
        _delayCoroutine = false;
    }
}
