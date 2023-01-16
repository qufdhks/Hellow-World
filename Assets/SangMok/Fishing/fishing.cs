using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishing : MonoBehaviour
{

    Vector3 originPos;
    public float F_Speed = 1f;

    public Transform m_Target;
    
    public float m_InitialAngle = 70f; // 처음 날라가는 각도
    private Rigidbody m_Rigidbody;

    //private float interval = 0.3f;

    private bool isAction = false;
    public bool isfishing;
    private bool onWater = false;

    //[SerializeField]
    private Transform fishingTr;
    //[SerializeField]
    private GameObject attachGo;

    public void SetAttachGo(GameObject _attachGo)
    {
        attachGo = _attachGo;
    }

    private void Awake()
    {
        fishingTr = transform;
    }

    void Start()
    {
        Debug.Log("Start: " + originPos);
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && !isAction)
        {
            originPos = transform.position;
            Vector3 velocity = GetVelocity(transform.position, m_Target.position, m_InitialAngle);
            m_Rigidbody.velocity = velocity;
            isAction = true;
            isfishing = false;
        }
    }

    public Vector3 GetVelocity(Vector3 player, Vector3 target, float initialAngle)
    {
        float gravity = Physics.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 planarTarget = new Vector3(target.x, 0, target.z);
        Vector3 planarPosition = new Vector3(player.x, 0, player.z);

        float distance = Vector3.Distance(planarTarget, planarPosition);
        float yOffset = player.y - target.y;

        float initialVelocity
            = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity
            = new Vector3(0f, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObjects
            = Vector3.Angle(Vector3.forward, planarTarget - planarPosition) * (target.x > player.x ? 1 : -1);
        Vector3 finalVelocity
            = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        return finalVelocity;
    }


    private void OnCollisionEnter(Collision col)
    {
        if (!onWater && col.gameObject.name == "Water")
        {
            StartCoroutine(MoveFish());
            StartCoroutine(FishingCoroutine());

            if (attachGo != null)
                attachGo.GetComponent<TargetFish>().MovingToTarget();

            onWater = true;
        }
    }

     private IEnumerator FishingCoroutine()
     {
        while (isAction)
        {
            if(attachGo != null && Input.GetKeyDown(KeyCode.J))
            {
                isfishing = true;
                Debug.Log("잡음");

                attachGo.transform.SetParent(fishingTr);
                Vector3 velocity = GetVelocity(transform.position, originPos, m_InitialAngle);
                m_Rigidbody.velocity = velocity;
                isAction = false;

                attachGo.GetComponent<TargetFish>().AttachProcess();

                onWater = false;
            }

            //yield return new WaitForSeconds(interval);
            yield return null;

            //isAction = false;
        }
     }

     private IEnumerator MoveFish()
     {
        Vector3 curPos = transform.position;
        while(isAction)
        {
            Vector3 newPos = curPos + (Vector3.up * Mathf.Sin(Time.time) * F_Speed);//sin*2 속도 빠르게, 폭을 넓게 F_Speed*2
            transform.position = newPos;
            yield return null;
        }

     }
}
