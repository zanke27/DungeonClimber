using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private GameObject _target => PlayerTrm.Target;

    private Vector3 result;
    private Vector3 targetDir;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(Vector2 pointerInput)
    {
        if (_target == null)
            result = Vector3.Cross(Vector2.up, pointerInput);
        else
        {
            Vector2 dir = _target.transform.position - transform.position;
            result = Vector3.Cross(Vector2.up, dir);
        }

        if (result.z > 0)
           _spriteRenderer.flipX = true;
        else if (result.z < 0)
            _spriteRenderer.flipX = false;
    }       
}
