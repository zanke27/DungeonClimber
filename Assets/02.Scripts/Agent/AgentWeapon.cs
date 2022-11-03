using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentWeapon : MonoBehaviour
{
    protected Weapon _weapon;

    protected WeaponRenderer _weaponRenderer;


    protected float _desireAngle;

    protected Vector2 _toEnemyVec;

    protected GameObject _target => player.Target;

    private Player player;
    
    private void Awake()
    {
        _weapon = GetComponentInChildren<Weapon>();
        _weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    public virtual void Attack()
    {
        _weapon.ShootBullet();
    }

    //public virtual void MoveDirAimWeapon(Vector2 dir)
    //{
    //    if (_weapon == null) return; // ����ִ� ���Ⱑ ���ų�
    //    if (dir == Vector2.zero) return; // �����̰� ���� �ʰų�

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

        transform.rotation = Quaternion.AngleAxis(_desireAngle, Vector3.forward); //z�� ���� ȸ��
    }

    private void AdjustWeaponRendering()
    {
        if (_weaponRenderer != null)
        {
            _weaponRenderer.FlipSprite(_desireAngle > 90f || _desireAngle < -90f); //���� true��?
            //_weaponRenderer.RenderBehindHead(_desireAngle > 0 && _desireAngle < 180);
        }
    }
}
