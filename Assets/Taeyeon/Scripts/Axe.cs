using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Axe : MonoBehaviour
{
    [SerializeField] private GameObject stump;
    [SerializeField] private GameObject woodPfs;

    public GameObject tree;

    int count = 0;

    private void Update()
    {
        //float h = Input.GetAxis("Horizontal");

        //Vector3 dir = new Vector3(0, 0, h);

        //transform.Translate(dir * 5f * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {

            //GetVelocity(wood.transform.position, pos, 70f);

            count++;
            Instantiate(woodPfs, transform.position + new Vector3(0, 0, count / 2), Quaternion.identity);
            if (count >= 3)
            {
                Instantiate(stump, other.transform.position, Quaternion.identity);
                tree = other.gameObject;
                count = 0;
                Destroy(other.gameObject);
            }
        }

    }




}
