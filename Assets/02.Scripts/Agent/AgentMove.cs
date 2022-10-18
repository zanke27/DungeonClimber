using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMove : MonoBehaviour
{
    

    protected Vector2 moveDir = Vector2.zero;

    // AgentInput을 따로 빼서 거기서 관리 할 예정
    JoyStick input = null;

    [SerializeField]
    private float speed = 10;

    private void Awake()
    {
        input = GameObject.Find("JoyStickPlace").GetComponent<JoyStick>();
    }

    // 움직임 벡터값 조정 최소값을 0.2로 이상하면 없앨거
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
