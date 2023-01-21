using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2  inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;

    //리지드 바디를 선언하고 추가함
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // inputVec.x = Input.GetAxis("Horizontal");
    //     // inputVec.y = Input.GetAxis("Vertical");
    //     inputVec.x = Input.GetAxisRaw("Horizontal");
    //     inputVec.y = Input.GetAxisRaw("Vertical");
    // }

    // 물리연산 프레임마다 호출되는 생명주기 함수
    void FixedUpdate() {
        // 1. 힘 추가
        // rigid.AddForce(inputVec);

        // 2. 속도제어
        // rigid.velocity = inputVec;

        // 3. 위치 이동 
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {   
        // nomalization 설정 했기 때문에 FixedUpdate에서 따로 설정하지 않아도됌
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate() 
    {   
        // inputVec.maginitue 벡터의 크기만 넣어주는 것이기 때문에 음수,양수 상관없이 작동
        anim.SetFloat("Speed", inputVec.magnitude);
        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x <0;
        }
    }
}
