# 2026-11-10 · 0단계 C + 1주차 과제 1~3

코드: [Day02_Practice.cs](Day02_Practice.cs) · [SpinningSquare.cs](SpinningSquare.cs) · [PlayerMove.cs](PlayerMove.cs) · [PlayerMoveRb.cs](PlayerMoveRb.cs)
문제: [0단계 연습문제](../../curriculum/0단계_연습문제.md) · [1주차 연습과제](../../curriculum/1주차_연습과제.md)

## 푼 문제

- 0단계 C-1 ~ C-5: Inspector 변수, Start/Update, 시간 재기, 위치 옮기기, 내 클래스(생성자 포함)
- 과제 1 도는 네모: `transform.Rotate`로 z축 회전
- 과제 2 움직이는 네모: WASD + 방향키, 대각선 속도 보정
- 과제 3 Rigidbody2D 이동: 벽에 막히는 이동

## 막힌 곳

- C-4: `Time.frameCount`를 시간처럼 써서 네모가 점점 빨라짐
- C-5: 다른 클래스의 `Hit`을 부르는 법 (`public`이 없어서 안 불림)
- 과제 2: 대각선 속도 보정 (`normalized`를 방향을 모으기 전에 해서 안 움직임)
- 과제 3: Update와 FixedUpdate 역할이 섞여서 안 움직임, 키를 떼도 계속 움직임, 혼자 아래로 내려감

## 찾아본 것

- `transform.Rotate`
- `Keyboard.current` + `isPressed`
- `Vector3.normalized`
- `GetComponent`, `FixedUpdate`, `Rigidbody2D.linearVelocity`

## 새로 안 것

- `Time.frameCount`는 프레임 번호, `Time.deltaTime`은 지난 프레임부터 걸린 시간. 이동/회전엔 deltaTime.
- 접근 제한자를 안 쓰면 `private`이라 다른 클래스에서 못 부른다. 밖에서 필요 없는 건 숨긴다.
- 2D 화면에서 팽이처럼 돌리려면 z축. x, y로 돌면 종이가 뒤집히듯 얇아진다.
- 같은 역할을 하는 변수 두 개(speed × angle)는 하나로 줄이고, 이름이 곧 설명이 되게 짓는다(`degreesPerSecond`).
- 대각선 (1, 1)의 길이는 √2 ≈ 1.41. **방향을 다 모은 뒤** `normalized`로 길이 1로 맞춘다. "if 안에서는 모으기만, 움직이는 건 마지막에 한 번".
- `transform.position`을 직접 바꾸면 순간이동이라 벽을 통과한다. 벽에 막히려면 Rigidbody2D의 속도로 움직인다.
- Update = 입력 읽기(direction), FixedUpdate = 물리(rb). velocity는 이미 "1초에 몇 칸"이라 deltaTime을 안 곱한다.
- 방향 변수를 메서드 밖에 두면 매 프레임 직접 0으로 비워야 한다.
- 탑다운 게임은 Rigidbody2D Gravity Scale을 0으로.

## 리뷰 후 정리한 것

- C-5: `enemyHp`를 다시 `private`으로, 사망 메시지도 문자열 보간으로
- 과제 1: `speed`, `angleX/Y/Z` → `degreesPerSecond` 하나로, z축만 회전
- 과제 2: 기본 속도 5, 키보드 없을 때 바로 나가는 `return` 방식으로
- 과제 3: 남아 있던 `transform.position +=` 줄 삭제(두 번 움직이던 문제), `direction`을 `Vector2`로, `Awake` + `[RequireComponent]` 적용 (1일차 `PlayerMovement.cs`와 비교 후)
