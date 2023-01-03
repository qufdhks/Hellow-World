using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pet : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    ObjData data;
   
    [SerializeField]  private int liking;
    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        data = GetComponent<ObjData>();
        target = GameObject.Find("petPosition");
    }

    private void Update()
    {
        if (liking >= data.needliking)
        {
            if (nav.destination != target.transform.position)
                nav.SetDestination(target.transform.position);
        }
        else
        {
            nav.SetDestination(transform.position);
        }
    }

    public void PlusLiking()
    {
        liking += 10;
    }


}
