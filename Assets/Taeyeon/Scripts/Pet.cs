using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public string _targetName = "Player";
    Transform _target;
    public bool _touch = false;
    private float dampSpeed = 3; //따라가는 속도

    private void Update()
    {
        if (_touch == true) FollowTarget();
    }

    public void TargetFind()
    {
        //타겟 string을 바꿈
        _target = GameObject.FindGameObjectWithTag(_targetName).GetComponent<Transform>();
    }

    void FollowTarget()
    {
        var heading = _target.position - this.transform.position;
        //거리가 멀어지면 실행
        if (heading.sqrMagnitude > 1)
        {
            // 목표물이 범위 내에 있음
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * dampSpeed);
        }

        //방향을 봄
        transform.LookAt(_target);
    }
    
}
