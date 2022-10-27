using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : PoolableMono
{
    [SerializeField]
    protected BulletDataSO _bulletDataSO;

    public virtual BulletDataSO BulletDataSO
    {
        get => _bulletDataSO;
        set => _bulletDataSO = value; // 이것도 먹나
    }

    protected bool _isEnemy;

    public bool IsEnemy
    {
        get => _isEnemy;
        set => _isEnemy = value; // 이거 되나
    }

    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }
}
