using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public GameObject Player;
    public GameObject firePosition; //�� �߻� ��ġ ����
    public GameObject SnowRock;//�� ������
    public float throwPower = 15f;//������ �� 
    public float SnowSpeed = 1f;//���ǵ�
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            GameObject bomb = Instantiate(SnowRock);
            bomb.transform.position = firePosition.transform.position;
            Rigidbody rb = bomb.GetComponent<Rigidbody>();
            rb.AddForce(Player.transform.forward * throwPower * SnowSpeed, ForceMode.Impulse);
        }
    }
}
