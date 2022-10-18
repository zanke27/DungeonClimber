using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData/GunDataSO")]
public class GunDataSO : ScriptableObject
{
    [Tooltip("���� ��������Ʈ")]
    public Sprite gunSprite;

    [Tooltip("�Ѿ��� ��������Ʈ")]
    public GameObject bulletPrefabs;

    [Space(10f)]
    [Tooltip("���� ������ (�Ѿ��� ��ü������ �������� ����)")]
    public float damage;

    [Tooltip("�Ѿ��� ���󰡴� �ӵ�")]
    public float bulletSpeed;

    [Tooltip("�Ѿ��� ������ ����")]
    public float bulletSpreadAngle;

    [Tooltip("�Ѿ��� ������ ����")]
    public float attackDelay;

    [Space(10f)]
    [Tooltip("�ڵ� ���� üũ")]
    public bool autoAttack = false;

    [Tooltip("��¡ ���� üũ")]
    public bool chargeAttack = false;

    [Space(10f)]
    [Tooltip("�Ѿ�(�ڿ�)�� �ִ�ġ")]
    public float maxBullet;

    [Tooltip("���� ���� �ڿ� (�Ѿ�)")]
    public float haveBullet;
}
