using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBullet : Bullet
{
    protected Rigidbody2D _rigidbody2D;
    protected SpriteRenderer _spriteRenderer;
    protected float _timeToLive;

    protected bool isDead = false;  

    protected int _enemyLayer;
    protected int _obstacleLayer;

    public override BulletDataSO BulletDataSO 
    { 
        get => _bulletDataSO;
        set 
        {
            base.BulletDataSO = value;

            if (_rigidbody2D == null)
                _rigidbody2D = GetComponent<Rigidbody2D>();

            if (_spriteRenderer == null)
                _spriteRenderer = GetComponent<SpriteRenderer>();

            if (IsEnemy)
                _enemyLayer = LayerMask.NameToLayer("Player");
            else
                _enemyLayer = LayerMask.NameToLayer("Enemy");
        }
    }

    private void Awake()
    {
        _obstacleLayer = LayerMask.NameToLayer("Obstacle");
        if (_rigidbody2D == null)
            _rigidbody2D = GetComponent<Rigidbody2D>();

        if (_spriteRenderer == null)
            _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        _timeToLive += Time.deltaTime;

        if (_timeToLive >= _bulletDataSO.lifeTime)
        {
            isDead = true;
            PoolManager.Instance.Push(this);
        }

        if (_rigidbody2D != null && _bulletDataSO != null)
        {
            _rigidbody2D.MovePosition(transform.position + _bulletDataSO.bulletSpeed * transform.right * Time.deltaTime);
        }
    }

    public override void Reset()
    {
        _timeToLive = 0;
        isDead = false;
    }
}
