using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemAI : MonoBehaviour
{
    public Transform goal;

    public float speedGolem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.speed = speedGolem;
        agent.destination = goal.position;
    }
}
