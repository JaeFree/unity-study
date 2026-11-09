using UnityEngine;

// 0단계 A(변수, if) + B(반복문, 배열, 메서드) 연습
// Practice 씬의 빈 오브젝트에 붙이고 Play → Console 확인
public class Practice0AB : MonoBehaviour
{
    // B-5. 깎인 HP를 돌려주되 0보다 작아지지 않게 한다
    int TakeDamage(int currentHp, int damage)
    {
        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
        return currentHp;
    }

    void Start()
    {
        // A-1. 변수 만들고 찍기
        int hp = 10;
        float speed = 5.5f;
        string playerName = "JaeFree";
        bool isAlive = true;
        Debug.Log(hp);         // 10
        Debug.Log(speed);      // 5.5
        Debug.Log(playerName); // JaeFree
        Debug.Log(isAlive);    // True

        // A-2. 값 바꾸기
        hp -= 3;
        Debug.Log(hp); // 7
        hp -= 2;
        Debug.Log(hp); // 5

        // A-3. 문자열 합치기
        Debug.Log(playerName + "의 HP : " + hp);
        // 문자열 보간: 앞에 $를 붙이고 {} 안에 변수를 넣는다
        Debug.Log($"{playerName}의 HP : {hp}");

        // A-4. if로 판단하기 (hp를 0, 5, -1로 바꿔가며 확인)
        if (hp <= 0)
        {
            Debug.Log("사망");
        }
        else
        {
            Debug.Log("생존");
        }

        // A-5. if / else if / else
        if (hp <= 0)
        {
            isAlive = false;
            Debug.Log(isAlive);
        }
        else if (hp >= 7)
        {
            Debug.Log("건강");
        }
        else if (hp >= 3)
        {
            Debug.Log("부상");
        }
        else
        {
            Debug.Log("위험");
        }

        // B-1. for로 세기: 1~10, 그다음 10~1
        int length = 10;
        for (int i = 1; i <= length; i++)
        {
            Debug.Log(i);
        }
        for (int i = length; i > 0; i--)
        {
            Debug.Log(i);
        }

        // B-2. 반복하며 데미지: 20에서 3씩 깎다가 0 이하면 멈춘다
        hp = 20;
        for (int i = 0; i < length; i++)
        {
            hp -= 3;
            Debug.Log("남은 HP : " + hp);
            if (hp <= 0)
            {
                Debug.Log("사망");
                break;
            }
        }

        // B-3. 배열과 foreach: 하나씩 찍고 합계 구하기
        // foreach 변수에는 번호가 아니라 값이 들어온다
        int[] enemyHps = { 5, 12, 3, 8 };
        int total = 0;
        foreach (var items in enemyHps)
        {
            Debug.Log(items);
            total += items;
        }
        Debug.Log(total); // 28

        // B-4. 가장 작은 값 찾기
        // 1. low를 배열의 첫 값으로 시작한다
        // 2. 배열 길이(enemyHps.Length)만큼 반복하며 low와 각 값을 비교한다
        // 3. low가 더 크면 그 값을 low에 저장한다
        // 4. 배열이 끝날 때까지 진행한다
        // 5. 반복이 끝난 뒤 low를 찍는다
        int low = enemyHps[0];
        for (int i = 0; i < enemyHps.Length; i++)
        {
            if (low >= enemyHps[i])
            {
                low = enemyHps[i];
            }
        }
        Debug.Log(low); // 3

        // B-5. 메서드 불러서 찍기
        Debug.Log(TakeDamage(10, 3)); // 7
        Debug.Log(TakeDamage(2, 5));  // 0
    }
}
