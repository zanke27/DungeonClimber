using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : Weapon
{
    #region ÃÑ °ü·Ã
    [SerializeField]
    private GunDataSO _gundataSO;

    public GunDataSO GunDataSO { get => _gundataSO; }

    [SerializeField]
    private GameObject _muzzle;

    [SerializeField]
    private bool _isEnemyBullet;
    #endregion

    #region ÃÑ¾Ë °ü·Ã

    [SerializeField] protected int _ammo; //ÇöÀç ÃÑ¾Ë ¼ö
    public int Ammo
    {
        get => _ammo;
        set => _ammo = Mathf.Clamp(value, 0, _gundataSO.maxBullet);
    }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        _ammo = _gundataSO.maxBullet;
        weaponType = WeaponType.Gun;
    }

    protected virtual void AutoAttack()
    {
        if (_isShooting && _delayCoroutine == false)
        {
            if (_ammo > 0)
            {
                _ammo -= 1;
                ShootBullet();
                StartCoroutine(DelayNextShootCoroutine());
            }
        }
    }

    bool isCharging = false;

    protected virtual void ChargeAttack()
    {
        if (_isShooting && _delayCoroutine == false && isCharging == false)
        {
            chargeTime = 0;
            isCharging = true;
            StartCoroutine(ChargeCorutine());
        }
    }

    private IEnumerator ChargeCorutine()
    {
        isCorStop = false;
        while (true)
        {
            chargeTime += Time.deltaTime;
            if (_isShooting == false) {
                isCharging = false;
                isCorStop = true;
                break;
            }
            
            if (chargeTime >= _gundataSO.chargeTime) {
                isCorStop = false;
                break;
            }
            yield return null;
        }

        if (isCorStop == false) { // Áß°£¿¡ Å¬¸¯À» ¸ØÃè´ÂÁö ¿©ºÎ
            yield return new WaitUntil(() => _isShooting == false);
            ShootBullet();
            StartCoroutine(DelayNextShootCoroutine());
            isCharging = false;
        }

        yield return null;
    }

    public override void Attack()
    {
        switch(_gundataSO.attackType)
        {
            case AttackType.AutoAttack:
                AutoAttack(); break;

            case AttackType.ChargeAttack:
                ChargeAttack(); break;
        }
    }

    public void ShootBullet()
    {
        SpawnBullet(_muzzle.transform.position, _muzzle.transform.rotation, _isEnemyBullet);
    }

    private void SpawnBullet(Vector3 pos, Quaternion rot, bool isEnemyBullet)
    {
        Bullet b = PoolManager.Instance.Pop(_gundataSO.bulletDataSO.bulletPrefabs.name) as Bullet;
        b.SetPositionAndRotation(pos, rot);
        b.IsEnemy = isEnemyBullet;
        b.BulletDataSO = _gundataSO.bulletDataSO;
    }

    protected IEnumerator DelayNextShootCoroutine()
    {
        _delayCoroutine = true;
        yield return new WaitForSeconds(_gundataSO.attackDelay);
        _delayCoroutine = false;
    }

    public Vector3 GetRightDirection()
    {
        return transform.right;
    }

    public Vector3 GetFirePosition()
    {
        return _muzzle.transform.position;
    }
}
