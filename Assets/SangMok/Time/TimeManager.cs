using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }
    [Header("Internal Clock")]
    public GameTimestamp timestamp;
    public float timeScale = 1.0f;

    [SerializeField] private Material mat;
    [SerializeField] private Material originMat;

    [SerializeField] private GameObject[] lights;

    [Header("Day and Night Cycle")]
    //디렉셔널 라이트(태양)의 변환
    public Transform sunTransform;
    
    //시간 변경을 알리는 객체 목록
    private List<ITimeTracker> listeners = new List<ITimeTracker>();

    private void Awake()
    {
        //인스턴스가 두 개 이상인 경우 추가 인스턴스를 삭제합니다.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            //정적 인스턴스를 이 인스턴스로 설정
            Instance = this;
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Year"))
            //타임스탬프 초기화
            timestamp = new GameTimestamp(6, 0);
        StartCoroutine(TimeUpdate());
    }

    private IEnumerator TimeUpdate()
    {
        while (true)
        {
            Tick();
            yield return new WaitForSeconds(1 / timeScale);
        }
    }
    //게임 내 시간의 틱
    public void Tick()
    {
        timestamp.UpdateClock(mat, originMat, lights);
        
        //청취자에게 새로운 시간 상태를 알립니다.
        foreach (ITimeTracker listener in listeners)
        {
            listener.ClockUpdate(timestamp);
        }

        UpdateSunMovement();

    }

    //낮과 밤 주기 함수
    void UpdateSunMovement()
    {
        
        //현재 시간을 분으로 변환
        int timeInMinutes = GameTimestamp.HoursToMinutes(timestamp.hour) + timestamp.minute;
        //태양은 1시간에 15도 이동
        //분당 0.25도 이동
        //자정(0:00)에 태양의 각도는 -90이어야 합니다.
        float sunAngle = 0.25f * timeInMinutes - 90;
        //디렉셔널 라이트에 각도 적용
        sunTransform.eulerAngles = new Vector3(sunAngle, 35f, 0);
    }
    
    //리스너 처리
    //리스너 목록에 개체 추가
    public void RegisterTracker(ITimeTracker listener)
    {
        listeners.Add(listener);
    }
    //리스너 목록에서 개체 제거
    public void UnregisterTracker(ITimeTracker listener)
    {
        listeners.Remove(listener);
    }
}
