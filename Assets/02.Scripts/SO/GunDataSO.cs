using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData/GunDataSO")]
public class GunDataSO : ScriptableObject
{
    [Tooltip("총의 스프라이트")]
    public Sprite gunSprite;

    [Tooltip("총알의 스프라이트")]
    public GameObject bulletPrefabs;

    [Space(10f)]
    [Tooltip("총의 데미지 (총알은 자체적으로 데미지가 없음)")]
    public float damage;

    [Tooltip("총알이 날라가는 속도")]
    public float bulletSpeed;

    [Tooltip("총알이 퍼지는 각도")]
    public float bulletSpreadAngle;

    [Tooltip("총알이 나가는 간격")]
    public float attackDelay;

    [Space(10f)]
    [Tooltip("자동 공격 체크")]
    public bool autoAttack = false;

    [Tooltip("차징 공격 체크")]
    public bool chargeAttack = false;

    [Space(10f)]
    [Tooltip("총알(자원)의 최대치")]
    public float maxBullet;

    [Tooltip("총의 남은 자원 (총알)")]
    public float haveBullet;
}
