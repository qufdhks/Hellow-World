using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCam : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, player.position.z - 5);
    }
}
