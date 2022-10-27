using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/WeaponData/BulletDataSO")]
public class BulletDataSO : ScriptableObject
{
    [Tooltip("�Ѿ��� ��������Ʈ")]
    public GameObject bulletPrefabs;

    [Space(10f)]
    [Tooltip("�Ѿ��� ������")]
    public float damage;

    [Tooltip("�Ѿ��� ���󰡴� �ӵ�")]
    public float bulletSpeed;

    [Header("�Ѿ� �ɷ� ����")]

    [Space(10f)]
    [Tooltip("���� ������ ƨ�����")]
    public bool isWallBounce = false;

    [Tooltip("���� ��� ƨ�����")]
    public int wallBounceCount;

    [Space(5f)]
    [Tooltip("���� ����ϴ���")]
    public bool isPassEnemy = false;

    [Tooltip("���� ����Ѵٸ� ����� ����ϴ���")]
    public int passEnemyCount;

    [Space(5f)]
    [Tooltip("�Ѿ��� ���� �ð�")]
    public float lifeTime = 2f;
}
