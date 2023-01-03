using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Pet"))
        {
            // 먹은 동물의 Pet이라는 스크립트를 들고와서 거기서
            // PulsLiking함수를 실행
            other.GetComponent<Pet>().PlusLiking();
            Destroy(gameObject);
        }
    }
}
