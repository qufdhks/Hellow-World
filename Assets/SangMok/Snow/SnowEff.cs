using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEff : MonoBehaviour
{
    public float destroyTime = 1f;//ȿ�� ���� �ð�
    float currentTime = 0;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(currentTime > destroyTime)
        {
            Destroy(gameObject);
        }

        currentTime = currentTime + Time.deltaTime;
    }
}
