using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicadaSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<AudioSource>().Play();
        this.GetComponent<BoxCollider>().enabled = false;
    }
}