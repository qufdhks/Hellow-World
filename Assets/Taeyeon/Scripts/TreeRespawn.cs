using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRespawn : MonoBehaviour
{
    [SerializeField] private GameObject tree;

    void Start()
    {
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);

        Instantiate(tree, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
