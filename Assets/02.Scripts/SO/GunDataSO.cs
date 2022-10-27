using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData/GunDataSO")]
public class GunDataSO : ScriptableObject
{
    [Header("�� ����")]
    [Tooltip("���� ��������Ʈ")]
    public Sprite gunSprite;

    [Tooltip("�Ѿ��� ������")]
    public BulletDataSO bulletDataSO;

    [Space(10f)]
    [Tooltip("�Ѿ��� ������ ����")]
    public float bulletSpreadAngle;

    [Tooltip("�Ѿ��� ������ ����")]
    public float attackDelay;

    [Space(10f)]
    [Tooltip("�Ѿ�(�ڿ�)�� �ִ�ġ")]
    public int maxBullet;

    [Tooltip("���� ���� �Ѿ� (�ڿ�)")]
    public int haveBullet;

    [Space(10f)]
    [Tooltip("�ڵ� ���� üũ (�ϳ��� �ؾ���)")]
    public bool autoAttack = false;

    [Tooltip("��¡ ���� üũ (�ϳ��� �ؾ���)")]
    public bool chargeAttack = false;
}
