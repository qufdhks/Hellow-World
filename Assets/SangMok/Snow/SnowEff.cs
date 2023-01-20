using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowEff : MonoBehaviour
{
    public float destroyTime = 1f;//효과 제거 시간
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
