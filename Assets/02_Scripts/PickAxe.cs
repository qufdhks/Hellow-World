using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxe : MonoBehaviour
{
    private new BoxCollider collider;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(OnOff());
        }
    }

    IEnumerator OnOff()
    {
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        collider.enabled = false;
    }
}
