using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public string _targetName = "Player";
    Transform _target;
    public bool _touch = false;
    private float dampSpeed = 3; //���󰡴� �ӵ�

    private void Update()
    {
        if (_touch == true) FollowTarget();
    }

    public void TargetFind()
    {
        //Ÿ�� string�� �ٲ�
        _target = GameObject.FindGameObjectWithTag(_targetName).GetComponent<Transform>();
    }

    void FollowTarget()
    {
        var heading = _target.position - this.transform.position;
        //�Ÿ��� �־����� ����
        if (heading.sqrMagnitude > 1)
        {
            // ��ǥ���� ���� ���� ����
            transform.position = Vector3.Lerp(transform.position, _target.position, Time.deltaTime * dampSpeed);
        }

        //������ ��
        transform.LookAt(_target);
    }
    
}
