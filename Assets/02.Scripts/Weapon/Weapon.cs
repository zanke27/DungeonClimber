using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    #region 총 관련
    [SerializeField]
    private GunDataSO _gundataSO;

    public GunDataSO GunDataSO { get => _gundataSO; }

    [SerializeField]
    private GameObject _muzzle;

    [SerializeField]
    private bool _isEnemyBullet;
    #endregion

    #region 발사 관련

    [SerializeField] protected bool _delayCoroutine = false;

    [SerializeField]
    protected bool _isShooting = false;

    protected float chargeTime = 0f;
    #endregion

    #region 총알 관련

    [SerializeField] protected int _ammo; //현재 총알 수
    public int Ammo
    {
        get => _ammo;
        set => _ammo = Mathf.Clamp(value, 0, _gundataSO.maxBullet);
    }

    #endregion

    protected Action AttackAction;

    protected virtual void Awake()
    {
        _ammo = _gundataSO.maxBullet;
        AttackActionInit();
    }

    private void Update()
    {
        UseWeapon();
    }

    // AttackAction에 Attack이라는 함수를 넣을 건데 바꿀필요가 있다면 이 함수를 바꿔서 Attack을 넣게
    protected virtual void AttackActionInit()
    {
        AttackAction -= Attack;
        AttackAction += Attack;
    }

    protected virtual void AutoAttack()
    {

    }

    protected virtual void ChargeAttack()
    {

    }

    private void UseWeapon()
    {
        
    }

    public virtual void Attack()
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

    public Vector3 GetRightDirection()
    {
        return transform.right;
    }

    public Vector3 GetFirePosition()
    {
        return _muzzle.transform.position;
    }

}
