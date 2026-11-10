using UnityEngine;

// 1주차 과제 1: 빙글빙글 도는 네모
// 1. 1초에 몇 도 돌지 정하는 변수 (Inspector에서 조절)
// 2. 매 프레임: 이번에 돌 각도 = 초당 각도 × 지난 프레임부터 걸린 시간
// 3. 그 각도만큼 z축으로 돌린다 (2D 화면에서 팽이처럼 돌려면 z축)
public class SpinningSquare : MonoBehaviour
{
    // 360이면 1초에 한 바퀴. 음수면 반대로 돈다.
    [SerializeField] private float degreesPerSecond = 90f;

    void Update()
    {
        transform.Rotate(0f, 0f, degreesPerSecond * Time.deltaTime);
    }
}
