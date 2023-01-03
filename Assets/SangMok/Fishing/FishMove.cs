using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    [SerializeField] private string animalName; // ������ �̸�
    

    [SerializeField] private float swimSpeed;  // �⺻�ӷ�

    private Vector3 direction;  // ����
    //private Vector3 limit_Move = new Vector3(3.0f, 0f, 3.0f);

    // ���� ����
    private bool isAction;  // �ൿ ������ �ƴ��� �Ǻ�
    [SerializeField] private bool isSwimming; // �ȴ���, �� �ȴ��� �Ǻ�

    [SerializeField] private float swimTime;  // ���� �ð�
    [SerializeField] private float waitTime;  // ��� �ð�
    private float currentTime;

    // �ʿ��� ������Ʈ
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rigidl;
    [SerializeField] private BoxCollider boxCol;

    //public Vector3 ClampPosition(Vector3 position)
    //{
        
    //    return new Vector3(Mathf.Clamp(position.x, -limit_Move.x, -limit_Move.x), -7f, 0);
    //}

    private void Awake()
    {
        //origin = transform.position;
    }

    void Start()
    {
        currentTime = waitTime;   // ��� ����
        isAction = true;   // ��⵵ �ൿ
    }

    void Update()
    {
        Move();
        Rotation();
        ElapseTime();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Water")
        {
            Swimming();
            SpeedSwimming();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == "Water")
        {
            isSwimming = false;

        }
    }

    private void Move()
    {
        //transform.position = ClampPosition(transform.position);

        //���� ������ ����
        if (isSwimming)
            rigidl.MovePosition(transform.position - transform.forward * swimSpeed * Time.deltaTime);
    }

    private void Rotation()
    {
        if (isSwimming)
        {
            //if (Physics.Raycast(transform.position, transform.forward, 4f, LayerMask.GetMask("Wall")))
            //{
            //    Vector3 rotation = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, 0), 0.5f);
            //    rigidl.MoveRotation(Quaternion.Euler(rotation));
            //}
            //else
            //{
                Vector3 _rotation = Vector3.Lerp(transform.eulerAngles, direction, 0.01f);
                rigidl.MoveRotation(Quaternion.Euler(_rotation));
            //}
        }
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)  // �����ϰ� ���� �ൿ�� ����
                ReSet();
        }
    }

    private void ReSet()  // ���� �ൿ �غ�
    {
        isSwimming = false;
        isAction = true;
        anim.SetBool("Swim1", isSwimming);

        direction.Set(0f, Random.Range(0f, 270f), 0f);

        RandomAction();
    }

    private void RandomAction()
    {
        int _random = Random.Range(0, 2); 

        if (_random == 0)
            Swimming();
        else if (_random == 1)
            SpeedSwimming();
        else if (_random == 2)
            dead();
      
    }

    private void Swimming()
    {
        isSwimming = true;
        currentTime = swimTime;
        anim.SetBool("Swim1", isSwimming);
        Debug.Log("����");
    }

    private void SpeedSwimming()  
    {
        isSwimming = true;
        currentTime = swimTime;
        anim.SetBool("Swim2", isSwimming);
        Debug.Log("���� ����");
    }

    private void dead()  
    {
        currentTime = waitTime;
        anim.SetTrigger("Dead");
        Debug.Log("����");
    }

}
