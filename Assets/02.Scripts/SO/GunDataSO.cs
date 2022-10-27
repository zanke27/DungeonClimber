using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData/GunDataSO")]
public class GunDataSO : ScriptableObject
{
    [Header("총 관련")]
    [Tooltip("총의 스프라이트")]
    public Sprite gunSprite;

    [Tooltip("총알의 데이터")]
    public BulletDataSO bulletDataSO;

    [Space(10f)]
    [Tooltip("총알이 퍼지는 각도")]
    public float bulletSpreadAngle;

    [Tooltip("총알이 나가는 간격")]
    public float attackDelay;

    [Space(10f)]
    [Tooltip("총알(자원)의 최대치")]
    public int maxBullet;

    [Tooltip("총의 남은 총알 (자원)")]
    public int haveBullet;

    [Space(10f)]
    [Tooltip("자동 공격 체크 (하나만 해야함)")]
    public bool autoAttack = false;

    [Tooltip("차징 공격 체크 (하나만 해야함)")]
    public bool chargeAttack = false;
}
