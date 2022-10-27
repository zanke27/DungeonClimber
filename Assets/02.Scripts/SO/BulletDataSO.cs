using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData/BulletDataSO")]
public class BulletDataSO : ScriptableObject
{
    [Tooltip("총알의 스프라이트")]
    public GameObject bulletPrefabs;

    [Space(10f)]
    [Tooltip("총알의 데미지")]
    public float damage;

    [Tooltip("총알이 날라가는 속도")]
    public float bulletSpeed;

    [Header("총알 능력 관련")]

    [Space(10f)]
    [Tooltip("벽에 맞으면 튕기는지")]
    public bool isWallBounce = false;

    [Tooltip("벽에 몇번 튕기는지")]
    public int wallBounceCount;

    [Space(5f)]
    [Tooltip("적을 통과하는지")]
    public bool isPassEnemy = false;

    [Tooltip("적을 통과한다면 몇마리나 통과하는지")]
    public int passEnemyCount;

    [Space(5f)]
    [Tooltip("총알의 생존 시간")]
    public float lifeTime = 2f;
}
