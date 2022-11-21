using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : AgentWeapon
{

    private List<Weapon> _weaponList = new List<Weapon>();
    private Player _player;
    private int _currentWeaponIndex = 0;
    private bool isChangeWeapon = false;

    private Weapon _currentWeapon = null;

    protected override void Awake()
    {
        _player = transform.parent.GetComponent<Player>();
    }

    public override void AssignWeapon()
    {
        _weapon = _currentWeapon;
        _weaponRenderer = _weapon?.WeaponRenderer;
    }

    protected void Start()
    {
        Weapon[] weapons = GetComponentsInChildren<Weapon>();

        // 3�� �÷��̾� �ִ� �� �������� �ٲ����
        for (int idx = 0; idx < 4; idx++)
        {
            if (weapons.Length <= idx)
            {
                _weaponList.Add(null);
            }
            else
            {
                _weaponList.Add(weapons[idx]);
                weapons[idx].gameObject.SetActive(false);
            }
        }

        // �Ѱ��� �ִٸ�
        if (_weaponList.Count > 0)
        {
            _currentWeapon = _weaponList[0]; // ���� ���� ��
            _currentWeapon.gameObject.SetActive(true); // ���ְ�
            AssignWeapon();
        }
    }

    public virtual void Shoot()
    {
        if (_weapon != null)
        {
            _weapon.TryShooting();
        }
    }

    public virtual void StopShooting()
    {
        if (_weapon != null)
        {
            _weapon.StopShooting();
        }
    }

    public virtual void Reload()
    {
        // ���ε� ������� �ϴ� �ڿ� �����ؼ� �� �����غ����ҵ�
    }



    
}
