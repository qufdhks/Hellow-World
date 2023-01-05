using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TargetFish : MonoBehaviour
{
    //NavMeshAgent nav;
    GameObject target;
    private Transform look;

    private fishing fishing;
    public static TargetFish Instance;

    //[SerializeField]
    //private GameObject poolingObjectPrefab;

    public bool attachFishing = false;


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

        //nav = GetComponent<NavMeshAgent>();
        //nav.enabled = true;
        target = GameObject.Find("fishing");
    }


    //void Update()
    //{
    //    if (!attachFishing) return;
    //    //if (nav.enabled == false) return;

    //    if (!fishing.isfishing)
    //    {
    //        //nav.enabled = true;
    //        transform.LookAt(look);
    //        transform.position = target.transform.position;
    //        //if (nav.destination != target.transform.position)
    //        //{
    //        //    nav.SetDestination(target.transform.position);
    //        //}
    //        //else
    //        //{
    //        //    nav.SetDestination(transform.position);
    //        //}
    //    }
    //    else
    //    {
    //        //nav.enabled = false;
    //        transform.localPosition = Vector3.zero;
    //        Destroy(gameObject, 3f);

    //        fishing.isfishing = false;
    //    }
    //}

    public void MovingToTarget()
    {
        StartCoroutine(MovingToTargetCoroutine());
    }

    private IEnumerator MovingToTargetCoroutine()
    {
        Vector3 startPos = transform.position;
        float t = 0f;
        while (t < 1f)
        {
            transform.LookAt(look);
            transform.position = Vector3.Lerp(startPos, target.transform.position, t);
            t += Time.deltaTime * 0.2f;
            yield return null;
        }

        Debug.Log("end");
        //target.GetComponent<fishing>().GetFishing();
    }
  
    public void AttachProcess()
    {
        transform.SetParent(target.transform);

        transform.localPosition = Vector3.zero;
        Destroy(gameObject, 3f);
    }
}
