using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider capColl;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        capColl = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        StartCoroutine(Drop(transform.position));
    }

    IEnumerator Drop(Vector3 _position)
    {
        float theta = Random.Range(0, 360f) * Mathf.Deg2Rad;
        Vector3 angle = new Vector3(-Mathf.Cos(theta), 0f, -Mathf.Sin(theta));
        Vector3 pos = angle * 5f;
        Debug.Log(pos);

        while (true)
        {
            capColl.isTrigger = true;
            if (_position == pos) 
            {
                capColl.isTrigger = false;
                break;
            }
            Vector3 velocity = GetVelocity(_position, pos, 20f);
            rb.velocity = velocity;

            yield return null;
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
}
