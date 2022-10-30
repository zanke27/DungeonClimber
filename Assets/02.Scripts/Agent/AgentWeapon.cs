using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon _weapon;

    protected WeaponRenderer _weaponRenderer;

    protected float _desireAngle;

    protected Vector2 _toEnemyVec;

    public GameObject target;

    private void Awake()
    {
        _weapon = GetComponentInChildren<Weapon>();
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }

    private void Update()
    {
        AimWeapon();
    }

    public virtual void Attack()
    {
        _weapon.ShootBullet();
    }

    public virtual void MoveDirAimWeapon(Vector2 dir)
    {
        if (_weapon == null) return; // 들고있는 무기가 없거나
        if (dir == Vector2.zero) return; // 움직이고 있지 않거나
        if (target != null) return; // 타겟이 있다면 리턴

        _desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        AdjustWeaponRendering();

        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward);
    }

    public virtual void AimWeapon()
    {
        if (_weapon == null) return;
        if (target == null) return;

        Vector2 pointerPos = target.transform.position;

        Vector3 aimDirection = (Vector3)pointerPos - transform.position;
        //360도 각도로 목적지까지의 각도를 계산하고
        _desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        //삼각형에서 

        AdjustWeaponRendering();

        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward); //z축 기준 회전
    }

    private void AdjustWeaponRendering()
    {
        if (_weaponRenderer != null)
        {
            _weaponRenderer.FlipSprite(_desireAngle > 90f || _desireAngle < -90f); //언제 true야?
            //_weaponRenderer.RenderBehindHead(_desireAngle > 0 && _desireAngle < 180);
        }
    }
}
