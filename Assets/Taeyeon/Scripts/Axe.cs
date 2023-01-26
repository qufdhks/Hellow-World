using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Axe : MonoBehaviour
{
    [SerializeField] private GameObject stump;
    [SerializeField] private GameObject woodPfs;
    private new BoxCollider collider;

    public GameObject tree;

    int count = 0;

    private void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            StartCoroutine(OnOff());
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {

            //GetVelocity(wood.transform.position, pos, 70f);
            collider.enabled = false;
            count++;
            Instantiate(woodPfs, transform.position + new Vector3(0, 0, count / 2), Quaternion.identity);
            if (count >= 3)
            {
                Instantiate(stump, other.transform.position, Quaternion.identity);
                tree = other.gameObject;
                count = 0;
                other.gameObject.SetActive(false);
            }
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
