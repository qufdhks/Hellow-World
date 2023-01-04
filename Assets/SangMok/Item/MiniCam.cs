using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCam : MonoBehaviour
{
    public GameObject YEJI_ZZANG;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - YEJI_ZZANG.transform.position;
    }

    void LateUpdate()
    {
        transform.position = YEJI_ZZANG.transform.position + offset;
    }
}
