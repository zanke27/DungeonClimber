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
        if (_weapon == null) return; // ����ִ� ���Ⱑ ���ų�
        if (dir == Vector2.zero) return; // �����̰� ���� �ʰų�
        if (target != null) return; // Ÿ���� �ִٸ� ����

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
        //360�� ������ ������������ ������ ����ϰ�
        _desireAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        //�ﰢ������ 

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
