using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/WeaponData/SwordDataSO")]
public class SwordDataSO : ScriptableObject
{
    [Tooltip("검의 스프라이트")]
    public Sprite swrodData;

    [Header("총알 관련")]
    [Tooltip("검에서 나오는 총알의 데이터")]
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
    [Tooltip("공격 타입")]
    public AttackType attackType;

    [Tooltip("차징 공격 시간")]
    public float chargeTime;
}
