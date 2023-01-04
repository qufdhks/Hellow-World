using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TargetFish : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    private Transform look;

    private fishing fishing;
    public static TargetFish Instance;

    [SerializeField]
    private GameObject poolingObjectPrefab;




    //void Start()
    //{
    //    nav = GetComponent<NavMeshAgent>();
    //    nav.enabled = false;
    //    target = GameObject.Find("fishing");
    //}

    public void Init(Transform _look, fishing _fishing)
    {
        look = _look;
        fishing = _fishing;

        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
        target = GameObject.Find("fishing");
    }


    void Update()
    {
        if (nav.enabled == false) return;

        if (!fishing.isfishing)
        {
            nav.enabled = true;
            transform.LookAt(look);
            if (nav.destination != target.transform.position)
            {
                nav.SetDestination(target.transform.position);
            }
            else
            {
                nav.SetDestination(transform.position);
            }
        }
        else
        {
            nav.enabled = false;
            transform.localPosition = Vector3.zero;
            Destroy(gameObject, 3f);

            fishing.isfishing = false;
        }
    }

  

    

}
