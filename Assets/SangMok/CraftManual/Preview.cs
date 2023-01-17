using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preview : MonoBehaviour
{
    Transform tf_Player = null;

    private void Awake()
    {
        tf_Player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = tf_Player.position + (tf_Player.forward * 10f) + new Vector3(0f, -1.5f, 0f);
        transform.LookAt(tf_Player.position);
        
    }

}
