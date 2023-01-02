using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int countPet;

    private void Start()
    {
        countPet = 0;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Pet")
        {
            countPet++;
            //1��° ���� ������Ʈ�� ���󰡰� �������� ���� ������Ʈ�� ���󰡰� string Ÿ�ٳ����� �ٲ�
            if(countPet > 1) col.GetComponent<Pet>()._targetName = "Pet" +(countPet - 1).ToString();

            //������Ʈ�� �±׸��� �ٲ�
            col.gameObject.tag = "Pet" + countPet.ToString();

            col.GetComponent<Pet>().TargetFind();
            col.GetComponent<Pet>()._touch = true;
        }
    }
}
