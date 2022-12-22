using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalAI : MonoBehaviour
{
    [SerializeField] private float WalkSpeed = 0.5f; // ∞»±‚ º”µµ

    [SerializeField] private List<Transform> wayPoints;
    [SerializeField] private int nextIdx;

    private bool isAction;
    private bool isWalking;

    [SerializeField] private float waitTime = 4f; // ∏ÿ√Á¿÷¥¬ Ω√∞£
    private float currentTime;

    [SerializeField] private Animator anim;
    [SerializeField] private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        currentTime = waitTime;
        isAction = true;
        nextIdx = Random.Range(0, wayPoints.Count);
    }

    void Update()
    {
        Move();
        ElapseTime();
    }

    private void Move()
    {
        if (isWalking)
        {
            agent.speed = WalkSpeed;
            agent.destination = wayPoints[nextIdx].position;
            if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
            {
                agent.speed = 0;
                currentTime = 0;
                isWalking = false;
            }
        }
    }

    private void ElapseTime()
    {
        if (isAction)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0 && !isWalking)   // ∑£¥˝«œ∞‘ ¥Ÿ¿Ω «‡µø ∞≥Ω√
                ReSet();

        }
    }

    private void ReSet()
    {
        isWalking = false;
        isAction = true;
        anim.SetBool("Walking", isWalking);

        RandomAction();
    }

    private void RandomAction()
    {
        int _random = Random.Range(0, 3);   // ¥Î±‚, ∞»±‚, «Æ∂‚±‚

        if (_random == 0)
            Wait();
        else if (_random == 1)
            Eat();
        else if (_random == 2)
            TryWalk();
    }

    private void Wait()
    {
        currentTime = waitTime;
    }

    private void Eat()
    {
        currentTime = waitTime;
        anim.SetTrigger("Eat");
    }

    private void TryWalk()
    {
        nextIdx++;
        nextIdx = Random.Range(0, wayPoints.Count);
        isWalking = true;
        anim.SetBool("Walking", isWalking);
    }
}
