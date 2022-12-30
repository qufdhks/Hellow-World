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
            //1번째 메인 오브젝트를 따라가고 다음부터 작은 오브젝트만 따라가게 string 타겟네임을 바꿈
            if(countPet > 1) col.GetComponent<Pet>()._targetName = "Pet" +(countPet - 1).ToString();

            //오브젝트의 태그명을 바꿈
            col.gameObject.tag = "Pet" + countPet.ToString();

            col.GetComponent<Pet>().TargetFind();
            col.GetComponent<Pet>()._touch = true;
        }
    }
}
