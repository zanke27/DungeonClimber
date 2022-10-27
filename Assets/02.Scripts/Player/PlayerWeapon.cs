using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : AgentWeapon
{


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
}
