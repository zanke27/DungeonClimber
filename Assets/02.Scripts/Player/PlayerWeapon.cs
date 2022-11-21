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

        // 3을 플레이어 최대 총 소지수로 바꿔야함
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

        // 한개라도 있다면
        if (_weaponList.Count > 0)
        {
            _currentWeapon = _weaponList[0]; // 제일 위에 총
            _currentWeapon.gameObject.SetActive(true); // 켜주고
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
        // 리로드 만들려면 일단 자원 관련해서 더 생각해봐야할듯
    }



    
}
