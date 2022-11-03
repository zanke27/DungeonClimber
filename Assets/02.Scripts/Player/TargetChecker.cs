using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetChecker : MonoBehaviour
{
    public float radious = 5f;

    [SerializeField]
    private LayerMask _targetLayer;

    private GameObject target;
    public GameObject Target => target;

    private void Awake()
    {
        //_targetLayer = LayerMask.NameToLayer("Enemy");
    }

    private void Update()
    {
        CheckTarget();
    }

    private void CheckTarget()
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, radious, _targetLayer);
        if (targets.Length > 0) // NULLüũ �ϸ� X -> Collider2D�� �迭�� ������ ��ſ� �ȿ� �ƹ��͵� ��������
        {
            float distance = Vector3.Distance(targets[0].transform.position, transform.position);
            foreach(Collider2D col in targets)
            {
                float eDistance = Vector2.Distance(transform.position, col.transform.position);
                if (eDistance <= distance)
                {
                    target = col.gameObject;
                }
            }
        }
        else
        {
            target = null;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        //if (UnityEditor.Selection.activeGameObject == gameObject) {}
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, radious);
            Gizmos.color = Color.white;
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(target.transform.position, 3);
        }
    }
#endif
}