using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon _weapon;

    protected WeaponRenderer _weaponRenderer;

    protected float _desireAngle;

    protected Vector2 _toEnemyVec;

    protected GameObject _target => PlayerTrm.Target;
    
    private void Awake()
    {
        _weapon = GetComponentInChildren<Weapon>();
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
    }

    //public virtual void MoveDirAimWeapon(Vector2 dir)
    //{
    //    if (_weapon == null) return; // 들고있는 무기가 없거나
    //    if (dir == Vector2.zero) return; // 움직이고 있지 않거나

    //    _desireAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

    //    AdjustWeaponRendering();

    //    transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward);
    //}

    public virtual void AimWeapon(Vector2 moveDir)
    {
        if (_weapon == null) return;
        if (moveDir == Vector2.zero && _target == null) return;

        if (_target != null)
        {
            Vector2 pointerPos = _target.transform.position;
            Vector3 aimDirection = (Vector3)pointerPos - transform.position;
            _desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        }
        else if(_target == null)
        {
            _desireAngle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
        }

        AdjustWeaponRendering();

        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward); //z축 기준 회전
    }

    private void AdjustWeaponRendering()
    {
        if (_weaponRenderer != null)
        {
            if (_weapon.weaponType == WeaponType.Gun)
            {
                _weaponRenderer.FlipSprite(_desireAngle > 90f || _desireAngle < -90f); //언제 true야?
            }
            else if (_weapon.weaponType == WeaponType.Sword)
            {
                if (_desireAngle > 90f || _desireAngle < -90f)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    _desireAngle -= 180;
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            //_weaponRenderer.RenderBehindHead(_desireAngle > 0 && _desireAngle < 180);
        }
    }
}
