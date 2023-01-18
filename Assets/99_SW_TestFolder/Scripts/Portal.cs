using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private Material mat;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Animal"))
        {
            other.transform.position = new Vector3(tr.position.x,tr.position.y,tr.position.z);
            //RenderSettings.skybox = mat;
            //DynamicGI.UpdateEnvironment();
            StartCoroutine(OnOff(other));
        }
    }

    IEnumerator OnOff(Collider _other)
    {
        _other.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        _other.gameObject.SetActive(true);
    }
}
