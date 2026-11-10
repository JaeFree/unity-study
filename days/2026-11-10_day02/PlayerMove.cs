using UnityEngine;
using UnityEngine.InputSystem;

// 1주차 과제 2: 방향키/WASD로 움직이는 네모 (transform으로 이동)
// 이동 속도 변수 (1초에 몇 칸)
// 매 프레임마다:
//     이번 프레임 방향을 (0, 0)으로 시작한다
//     오른쪽 키 → 방향의 x를 +1, 왼쪽 키 → -1
//     위 키 → 방향의 y를 +1, 아래 키 → -1
//     방향을 다 모은 뒤 normalized로 길이를 1로 맞춘다 (대각선이 √2 ≈ 1.41배 빨라지는 것 방지)
//     위치 += 방향 × 속도 × Time.deltaTime (한 번만)
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    void Update()
    {
        if (Keyboard.current == null) return;

        Vector3 direction = Vector3.zero;

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
        transform.position += direction * speed * Time.deltaTime;
    }
}
