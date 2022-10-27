using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : Weapon
{
    public override void Attack()
    {
        if (_isShooting && _delayCoroutine == false)
        {
            if (_ammo > 0)
            {
                _ammo -= 5;
                ShootBullet();
                StartCoroutine(DelayNextShootCoroutine());
            }
        }
    }
}