using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatAI : MonoBehaviour
{
    public Transform goal;

    public GameObject bat;
    public GameObject newBat;

    public Vector3 pos;
    public Vector3 flyUp;
    public Vector3 targetDirection;
    public Vector3 direction;

    public RaycastHit inRange;
    public RaycastHit fly;

    public float speedBat;
    public float rotationSpeed;
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
        attack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //navigation, this makes the bat move towards the player
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

        if (attack >= 21 && attack <= 96)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.speed = hitSpeed;
        }

        if (attack >= 97)
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(newBat, pos, Quaternion.identity);
                attack = 0;
            }
        }

        if (Physics.Raycast(transform.position, Vector3.down, out fly, 10))
        {
            GetComponent<Transform>().position += flyUp;
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
