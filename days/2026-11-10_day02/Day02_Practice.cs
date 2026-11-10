using UnityEngine;

// 0단계 C: 클래스와 Unity 기본 (Inspector, Start/Update, 시간, 위치, 내 클래스)
// Square 오브젝트에 붙이고 Play → Console 확인
public class Day02_Practice : MonoBehaviour
{
    // C-1. Inspector에 변수 보이기
    // Inspector에서 값을 바꾸면 코드에 쓴 값보다 Inspector 값이 우선한다
    public int hp = 10;
    [SerializeField] private float speed = 3f;

    // C-3. 시간 재기용
    private float timer = 0f;

    void Start()
    {
        // C-1
        Debug.Log(hp);
        Debug.Log(speed);

        // C-2. Start는 처음 한 번, Update는 매 프레임 계속 불린다
        Debug.Log("Start");

        // C-4. 위치 찍고 (3, 2, 0)으로 옮기기
        Debug.Log(transform.position);
        transform.position = new Vector3(3f, 2f, 0f);

        // C-5. 같은 설계도(클래스)로 만든 두 마리는 HP가 따로 논다
        Enemy goblin = new Enemy("고블린", 100);
        Enemy skeleton = new Enemy("스켈레톤", 200);
        goblin.Hit(100);   // 고블린 HP : 0, 고블린 사망
        skeleton.Hit(150); // 스켈레톤 HP : 50
    }

    void Update()
    {
        // C-2. 확인용 (매 프레임 찍혀서 확인 후 주석 처리)
        // Debug.Log("Update " + Time.frameCount);

        // C-3. 1초마다 "1초 지남"
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            Debug.Log("1초 지남");
            timer = 0f;
        }

        // C-4. 1초에 speed칸씩 오른쪽으로
        // Time.frameCount는 시간이 아니라 프레임 번호라 쓰면 점점 빨라진다 → Time.deltaTime 사용
        transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}

// C-5. MonoBehaviour를 상속하지 않는 내 클래스
public class Enemy
{
    private string enemyName;
    private int enemyHp; // 밖에서 읽을 일이 없으니 숨긴다

    // 생성자: new Enemy("이름", HP)로 만들 때 불린다
    public Enemy(string name, int hp)
    {
        enemyName = name;
        enemyHp = hp;
    }

    // 밖(Day02_Practice)에서 부르려면 public이 필요하다
    public void Hit(int damage)
    {
        enemyHp -= damage;
        Debug.Log($"{enemyName} HP : {enemyHp}");
        if (enemyHp <= 0)
        {
            Debug.Log($"{enemyName} 사망");
        }
    }
}
