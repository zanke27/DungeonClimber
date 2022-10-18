using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    

    protected Vector2 moveDir = Vector2.zero;

    // AgentInput�� ���� ���� �ű⼭ ���� �� ����
    JoyStick input = null;

    [SerializeField]
    private float speed = 10;

    private void Awake()
    {
        input = GameObject.Find("JoyStickPlace").GetComponent<JoyStick>();
    }

    // ������ ���Ͱ� ���� �ּҰ��� 0.2�� �̻��ϸ� ���ٰ�
    protected virtual void SetMoveDir()
    {
        moveDir.x = input.inputDir == Vector2.zero ? 0 : 
            Mathf.Clamp(Mathf.Abs(input.inputDir.x), 0.2f, 1) * (Mathf.Abs(input.inputDir.x) / input.inputDir.x);
        moveDir.y = input.inputDir == Vector2.zero ? 0 : 
            Mathf.Clamp(Mathf.Abs(input.inputDir.y), 0.2f, 1) * (Mathf.Abs(input.inputDir.y) / input.inputDir.y);
    }

    private void FixedUpdate()
    {
        SetMoveDir();
        gameObject.transform.Translate(moveDir * Time.deltaTime * speed);
    }
}
