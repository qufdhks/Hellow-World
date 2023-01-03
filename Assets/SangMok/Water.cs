using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public static bool isWater = false;

    

    [SerializeField] private float waterDrag; // 물 속 중력
    //private float originDrag; // 물 밖 세상의 원래 저항력

    [SerializeField] private Color waterColor; // 낮의 물 속 Fog 색깔
    [SerializeField] private float waterFogDensity; // 낮의 물 속 탁한 정도

    private Color originColor;
    private float originFogDensity;


    void Start()
    {
        originColor = RenderSettings.fogColor;
        originFogDensity = RenderSettings.fogDensity;

        //originDrag = 0;
    }
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GetInWater(other.transform);  // 물에 들어감
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        { 
            GetOutWater(other);  // 물에서 나옴
        }
    }



    private void GetInWater(Transform _player)
    {
        isWater = true;
        //_player.transform.GetComponent<Rigidbody>().drag = waterDrag;// 중력저항 ==> 천천히 가라앉음
        //_player.position.y -= waterDrag * Time.deltaTime;

        RenderSettings.fogColor = waterColor;
        RenderSettings.fogDensity = waterFogDensity;

    }

    private void GetOutWater(Collider _player)
    {
        if(isWater)
        {
            isWater = false;
            //_player.transform.GetComponent<Rigidbody>().drag = originDrag;

            RenderSettings.fogColor = originColor;
            RenderSettings.fogDensity = originFogDensity;

        }
    }
}