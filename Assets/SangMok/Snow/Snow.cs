using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public GameObject Player;
    public GameObject firePosition; //´« ¹ß»ç À§Ä¡ ÁöÁ¤
    public GameObject SnowRock;//´« ÇÁ¸®ÆÕ
    public float throwPower = 15f;//´øÁö´Â Èû 
    public float SnowSpeed = 1f;//½ºÇÇµå
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
