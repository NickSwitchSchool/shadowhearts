using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemAI : MonoBehaviour
{
    public Transform goal;

    public Vector3 pos;
    public Vector3 targetDirection;
    public Vector3 direction;

    public RaycastHit inRange;

    public float speedGolem;
    public float rotationSpeed;
    public float attackRange;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.speed = speedGolem;
    }

    // Update is called once per frame
    void Update()
    {
        targetDirection = goal.position - transform.position;
        direction = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
        pos = transform.position;
        if (Physics.Raycast(transform.position, transform.forward, out inRange, attackRange))
        {
            if (inRange.transform.tag == "Player")
            {
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }
        }
    }
}
