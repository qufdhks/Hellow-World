using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("petPosition");
    }

    private void Update()
    {
        if(nav.destination != target.transform.position)
        {
            nav.SetDestination(target.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }
    }
}
