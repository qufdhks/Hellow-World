using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSnow : MonoBehaviour
{
    public GameObject snowEff;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(snowEff);//����Ʈ ������ ����
        eff.transform.position = transform.position;//����Ʈ ������ ��ġ ����
        Destroy(gameObject);//������ �ı�
    }
}
