using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    [SerializeField] private string animalName; // 동물의 이름
    //[SerializeField] private int hp;  // 동물의 체력

    [SerializeField] private float swimSpeed;  // 기본속력

    private Vector3 direction;  // 방향

    // 상태 변수
    private bool isAction;  // 행동 중인지 아닌지 판별
    private bool isSwimming; // 걷는지, 안 걷는지 판별

    [SerializeField] private float swimTime;  // 수영 시간
    [SerializeField] private float waitTime;  // 대기 시간
    private float currentTime;

    // 필요한 컴포넌트
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigidl;
    [SerializeField] private BoxCollider boxCol;

    void Start()
    {
        currentTime = waitTime;   // 대기 시작
        isAction = true;   // 대기도 행동
    }

    void Update()
    {
        Move();
        Rotation();
        ElapseTime();
    }

    private void Move()
    {
        //수영 가능한 공간
        if (isSwimming)
            rigidl.MovePosition(transform.position - transform.forward * swimSpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        if (isSwimming)
        {
            Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.01f);
            rigidl.MoveRotation(Quaternion.Euler(_rotation));
        }
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)  // 랜덤하게 다음 행동을 개시
                ReSet();
        }
    }

    private void ReSet()  // 다음 행동 준비
    {
        isSwimming = false;
        isAction = true;
        anim.SetBool("Swim1", isSwimming);

        direction.Set(0f, Random.Range(0f, 360f), 0f);

        RandomAction();
    }

    private void RandomAction()
    {
        int _random = Random.Range(0, 2); 

        if (_random == 0)
            Swimming();
        else if (_random == 1)
            Swimming();
        else if (_random == 2)
            dead();
      
    }

    private void Swimming()
    {
        isSwimming = true;
        currentTime = swimTime;
        anim.SetBool("Swim1", isSwimming);
        Debug.Log("수영");
    }

    private void SpeedSwimming()  
    {
        isSwimming = true;
        currentTime = swimTime;
        anim.SetBool("Swim2", isSwimming);
        Debug.Log("빠른 수영");
    }

    private void dead()  
    {
        currentTime = waitTime;
        anim.SetTrigger("Dead");
        Debug.Log("죽음");
    }

}
