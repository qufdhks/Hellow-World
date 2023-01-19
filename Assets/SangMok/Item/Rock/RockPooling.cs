using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPooling : MonoBehaviour
{

    [Header("돌 생성 변수")]
    public Transform[] points; //스폰 위치
    public GameObject DesRock;
    public float createTime = 5f;//생성 주기
    public int maxRock = 10;

    public bool isGameOver = false;

    public static RockPooling instance;

    private void Awake()
    {
        if (instance == null)
        {
            //해당 게임 매니저(자기자신)을 할당
            instance = this;
        }
        //instance에 할당된 클래스가 자기 자신이 아니라면 새로 생성된 클래스를 의미함 결국 클래스 체크하는이유는
        //유니크하게 해당 게임에 GameManger가 하나만 존재하도록 하려고
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        //씬 변경이 일어나더라도 삭제하지 않고 계속 유지
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if (points.Length > 0)
        {
            //Enemy 자동 생성 코루틴 함수 호출
            StartCoroutine(CreatRock());
        }
        
    }

    IEnumerator CreatRock()
    {
        //게임 종료 전까지 무한루프
        //while (!isGameOver)
        while (true)
        {
            //ENEMY 태그를 지닌 오브젝트의 갯수 파악
            //최대 10마리를 넘기지 않기 위해서
            GameObject[] Rocks = GameObject.FindGameObjectsWithTag("Rock");
            if (Rocks == null || Rocks.Length == 0)
            {
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(0, points.Length);
                GameObject goRock = Instantiate(DesRock,//Enemy, 프리팹
                            points[idx].position,//랜덤추출된 위치
                            points[idx].rotation);//랜덤추출된 위치의 회전값
              
            }
            yield return null;
        }
    }
}
