using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CurrentTime : MonoBehaviour
{
    [SerializeField]
    Text  time1;

    void Update()
    {
        
        time1.text = DateTime.Now.ToString("tt\nh : mm : ss");
        //time2.text = DateTime.Now.ToString("tth : mm : ss");
    }
}
