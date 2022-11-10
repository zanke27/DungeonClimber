using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "SO/WeaponData/SwordDataSO")]
public class SwordDataSO : ScriptableObject
{
    [Tooltip("���� ��������Ʈ")]
    public Sprite swrodData;

    [Header("�Ѿ� ����")]
    [Tooltip("�˿��� ������ �Ѿ��� ������")]
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
    [Tooltip("���� Ÿ��")]
    public AttackType attackType;

    [Tooltip("��¡ ���� �ð�")]
    public float chargeTime;
}
