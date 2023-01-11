using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pet"))
        {
            // ���� ������ Pet�̶�� ��ũ��Ʈ�� ���ͼ� �ű⼭
            // PulsLiking�Լ��� ����
            other.GetComponent<Pet>().PlusLiking();
            Destroy(gameObject);
        }
    }
}
