using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AgentRenderer : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public GameObject target;

    private Vector3 result;
    private Vector3 targetDir;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FaceDirection(Vector2 pointerInput)
    {
        Vector2 dir = target.transform.position - transform.position;

        if (target == null)
            result = Vector3.Cross(Vector2.up, pointerInput);
        else
            result = Vector3.Cross(Vector2.up, dir);

        if (result.z > 0)
           _spriteRenderer.flipX = true;
        else if (result.z < 0)
            _spriteRenderer.flipX = false;
    }       
}
