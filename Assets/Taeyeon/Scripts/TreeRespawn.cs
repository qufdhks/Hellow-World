using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeRespawn : MonoBehaviour
{
    private Axe axe;
    GameObject tree;

    void Start()
    {
        axe = GameObject.FindWithTag("Axe").GetComponent<Axe>();
        tree = axe.tree;
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(15f);

        //Instantiate(tree, gameObject.transform.position, Quaternion.identity);
        tree.SetActive(true);
        Debug.Log("º“»Ø!");
        Destroy(gameObject);
    }
}
