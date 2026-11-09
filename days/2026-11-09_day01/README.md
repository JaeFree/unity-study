# 2026-11-09 · 0단계 A, B (변수 · if · 반복문 · 배열 · 메서드)

코드: [Practice0AB.cs](Practice0AB.cs) · 문제: [0단계 연습문제](../../curriculum/0단계_연습문제.md)

## 푼 문제

- A-1 ~ A-5: 변수, 값 바꾸기, 문자열 합치기, if / else if / else
- B-1 ~ B-5: for, break, 배열과 foreach, 최솟값 찾기, 값을 돌려주는 메서드

## 막힌 곳

- 문자열 보간 쓰는 법
- `enemyHps.length`가 에러 (대소문자)
- foreach에서 값 꺼내는 법 (`enemyHps[items]`로 써서 범위 초과 에러)
- 가장 작은 값을 찾는 방법

## 찾아본 것

- 문자열 보간 문법
- foreach 문 구성

## 새로 안 것

- `Debug.Log`로 Console에 값을 찍어 확인할 수 있다.
- 문자열 보간: `$"{playerName}의 HP : {hp}"`
- C#은 대소문자를 구분한다. 배열 길이는 `Length`. 자동완성 목록에서 고르면 오타가 줄어든다.
- `foreach (var x in 배열)`의 `x`는 번호가 아니라 **값**이다.
- 실행 중 에러가 나면 그 줄에서 멈추고 아래 코드는 실행되지 않는다.
- `int`를 돌려주는 메서드는 `return`이 꼭 있어야 하고, 결과를 쓰려면 `Debug.Log(TakeDamage(10, 3))`처럼 받아서 써야 한다.
- 최솟값 찾기: "지금까지 가장 작은 값"을 **배열의 첫 값으로** 시작해서, 더 작은 값이 나오면 바꿔치기. 0으로 시작하면 답이 항상 0이 된다.

## 리뷰 후 고친 것

- B-3: `enemyHps[items]` → `items` (foreach 변수가 값이라서)
- B-4: `low` 시작값 0 → `enemyHps[0]`, `enemyHps[length]` → `enemyHps.Length`, 결과 출력을 반복문 밖으로
- B-5: `return` 추가, 호출 결과를 `Debug.Log`로 출력
- A-5: `else`로 "위험" 추가
