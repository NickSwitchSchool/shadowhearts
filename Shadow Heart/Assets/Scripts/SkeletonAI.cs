using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAI : MonoBehaviour
{
    public Transform goal;

    public int attack;

    public float speedSkeleton;
    public float idleTimer;
    public float rotationSpeed;
    public float attackRange;

    public Vector3 direction;
    public Vector3 targetDirection;
    public Vector3 pos;
    public Vector3 idleRotation;
    public Vector3 idleMovement;

    public bool hasIdleRotation;

    public GameObject skeleton;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        attack = 0;
        UnityEngine.AI.NavMeshAgent agent = skeleton.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speedSkeleton;
        goal = spawner.GetComponent<Spawner>().player;
    }

    // Update is called once per frame
    void Update()
    {
        //navigation, this makes the bat move towards the player
        targetDirection = goal.position - transform.position;
        pos = transform.position;
        float distance = Vector3.Distance(transform.position, goal.position);
        if (distance < attackRange)
        {
            direction = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = goal.position;
            agent.speed = speedSkeleton;
        }
        else
        {
            //idle, makes the bat move in random directions
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.speed = 0;
            idleTimer += Time.deltaTime;
            if (idleTimer >= 2)
            {
                if (hasIdleRotation == false)
                {
                    idleRotation.y = Random.Range(-rotationSpeed, rotationSpeed);
                    hasIdleRotation = true;
                }
                else
                {
                    transform.Rotate(idleRotation / 12);
                }
            }

            if (idleTimer >= 3)
            {
                idleTimer = 0;
                hasIdleRotation = false;
            }
            GetComponent<Transform>().Translate(idleMovement * Time.deltaTime * speedSkeleton);
        }
    }
}
