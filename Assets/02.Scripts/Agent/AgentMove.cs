using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    protected Vector2 _moveDir = Vector2.zero;
    protected Rigidbody2D _rigidbody2D = null;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    [SerializeField]
    private float speed = 10;

    // 움직임 벡터값 조정 최소값을 0.2로 이상하면 없앨거 ->일단 잠시 보류
    public void SetMoveDir(Vector2 direction)
    {
        _moveDir = direction;

        /*
        _moveDir.x = direction == Vector2.zero ? 0 : 
            Mathf.Clamp(Mathf.Abs(direction.x), 0.2f, 1) * (Mathf.Abs(direction.x) / direction.x);
        _moveDir.y = direction == Vector2.zero ? 0 : 
            Mathf.Clamp(Mathf.Abs(direction.y), 0.2f, 1) * (Mathf.Abs(direction.y) / direction.y);
        */
    }

    private void FixedUpdate()
    {
        _rigidbody2D.velocity = _moveDir * speed;
    }
}
