using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RcokCreate : MonoBehaviour
{
    [SerializeField] private GameObject rock;
    [SerializeField] private GameObject debris;
    [SerializeField] private GameObject stone;

    private GameObject originRock;

    [SerializeField] private int hp;
    [SerializeField] private float destroyTime;

    private void Start()
    {
        originRock = Instantiate(rock, transform.position, Quaternion.identity);
        originRock.transform.SetParent(transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon") && originRock != null)
        {
            Instantiate(stone, transform.position, Quaternion.identity);
            Destroy(originRock);
            GameObject _debris = Instantiate(debris, transform.position, Quaternion.identity);
            Destroy(_debris, 1f);
            StartCoroutine(CreateStone());
        }
    }

    IEnumerator CreateStone()
    {
        yield return new WaitForSeconds(5f);
        GameObject _rock = Instantiate(rock, transform.position, Quaternion.identity);
        originRock = _rock;
    }
}
