using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BatAI : MonoBehaviour
{
    public Transform goal;

    public GameObject bat;
    public GameObject newBat;
    public GameObject spawner;

    public Vector3 pos;
    public Vector3 flyUp;
    public Vector3 targetDirection;
    public Vector3 direction;
    public Vector3 idleRotation;
    public Vector3 idleMovement;

    public RaycastHit fly;
    public RaycastHit hit;

    public float speedBat;
    public float rotationSpeed;
    public float hitSpeed;
    public float hitDuration;
    public float attackDelay;
    public float attackRange;
    public float idleTimer;
    public float damageDealt;
    public float hpBat;

    public int attack;

    public bool hasIdleRotation;
    public bool hpHasBeenSet;
    public bool damageDone;

    // Start is called before the first frame update
    void Start()
    {
        attack = 0;
        NavMeshAgent agent = bat.GetComponent<NavMeshAgent>();
        agent.speed = speedBat;
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
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
            agent.speed = speedBat;
        }
        else
        {
            //idle, makes the bat move in random directions
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
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
            GetComponent<Transform>().Translate(idleMovement * Time.deltaTime * speedBat);
        }

        //attack, every 3 seconds the bat does a random attack or just nothing
        attackDelay += Time.deltaTime;

        if (attackDelay >= 4 && attack == 0)
        {
            if (distance < attackRange)
            {
                attack = Random.Range(1, 100);
            }
            else
            {
                attack = 0;
                attackDelay = 0;
                damageDone = false;
            }
        }

        if (attackDelay >= 4 && attackDelay <= 5 && attack <= 97)
        {
            flyUp.y += Time.deltaTime;
        }

        if (attackDelay >= 5 && attackDelay <= 7 && attack <= 97)
        {
            flyUp.y -= Time.deltaTime / 2;
        }

        if (attackDelay >= 7 && attack <= 97)
        {
            attackDone();
        }

        if (attackDelay >= 4 && attack >= 98)
        {
            Instantiate(newBat, pos, Quaternion.identity);
            attackDone();
        }

        if (Physics.Raycast(transform.position, Vector3.down, out fly, 10) && attackDelay >= 5)
        {
            GetComponent<Rigidbody>().velocity = flyUp;
        }

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 0.5f))
        {
            if (hit.transform.gameObject.tag == "Player" && attack <= 97 && attackDelay >= 5 && damageDone == false)
            {
                damageDealt = spawner.GetComponent<Difficulty>().dmg * 7;
                goal.GetComponent<HealtPoints>().hp -= damageDealt;
                damageDone = true;
            }
        }

        //hp
        if (spawner.GetComponent<Difficulty>().hp != 0 && hpHasBeenSet == false)
        {
            hpHasBeenSet = true;
            hpBat = spawner.GetComponent<Difficulty>().hp;
        }

        if (hpBat <= 0 && hpHasBeenSet == true)
        {
            print("bat died");
        }
    }

    void attackDone()
    {
        damageDone = false;
        attackDelay = 0;
        attack = 0;
    }
}
