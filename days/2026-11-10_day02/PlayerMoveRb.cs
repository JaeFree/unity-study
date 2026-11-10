using UnityEngine;
using UnityEngine.InputSystem;

// 1주차 과제 3: Rigidbody2D로 이동 (벽에 막히는 이동)
// 준비: Rigidbody2D Gravity Scale 0, Freeze Rotation Z 체크, BoxCollider2D
//
// 역할 나누기
//   Update      → direction만 건드린다 (키 읽어서 방향 모으기 → 정규화)
//   FixedUpdate → rb만 건드린다 (속도 = 방향 × 속도)
// transform.position을 직접 바꾸면 순간이동이라 벽을 통과한다 → 이동은 rb에게 맡긴다
// velocity는 이미 "1초에 몇 칸"이라 Time.deltaTime을 곱하지 않는다
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoveRb : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 direction; // Update와 FixedUpdate가 같이 쓰니 메서드 밖에 둔다

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 새 프레임마다 비우고 다시 모은다 (안 비우면 키를 떼도 계속 움직인다)
        direction = Vector2.zero;
        if (Keyboard.current == null) return;

        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed)
        {
            direction.y += 1;
        }
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            direction.x -= 1;
        }
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed)
        {
            direction.y -= 1;
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            direction.x += 1;
        }

        direction = direction.normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed;
    }
}
