using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatAI : MonoBehaviour
{
    public Transform goal;

    public GameObject bat;

    public Vector3 pos;

    public RaycastHit inRange;

    public float speedBat;
    public float hitSpeed;
    public float hitDuration;
    public float attackDelay;
    public float attackRange;

    public int attack;
    public int damageDealt;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.speed = speedBat;
    }

    // Update is called once per frame
    void Update()
    {
        //navigation, this makes the bat move towards the player
        transform.LookAt(goal);
        pos = transform.position;
        if (Physics.Raycast(transform.position, transform.forward, out inRange, attackRange))
        {
            if (inRange.transform.tag == "Player")
            {
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.destination = goal.position;
            }
        }

        //attack, every 3 seconds the bat does a random attack or just nothing
        attackDelay += Time.deltaTime;

        if (attackDelay >= 0.7f)
        {
            attack = 0;
        }

        if (attackDelay >= 3)
        {
            attack = Random.Range(0, 99);
            attackDelay = 0;
        }

        if (attack <= 20)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.speed = speedBat;
        }

        if (attack >= 21 && attack <= 90)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.speed = hitSpeed;
        }

        //Here comes a different attack later
        if (attack >= 91)
        {
            Instantiate(bat, pos, Quaternion.identity);
            attack = 0;
        }
    }

    private void OnCollisionEnter(Collision playerHit)
    {
        if (playerHit.gameObject.tag == "Player")
        {
            damageDealt = 7;
        }
    }
}
