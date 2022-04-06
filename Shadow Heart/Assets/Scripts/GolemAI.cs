using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GolemAI : MonoBehaviour
{
    public Transform goal;

    public GameObject spawner;
    public GameObject rock;

    public Vector3 pos;
    public Vector3 rockPos;
    public Vector3 targetDirection;
    public Vector3 direction;
    public Vector3 idleRotation;
    public Vector3 idleMovement;
    public Vector3 rockMovement;

    public RaycastHit hit;

    public float speedGolem;
    public float rotationSpeed;
    public float attackRange;
    public float idleTimer;
    public float hpGolem;
    public float attackTimer;
    public float nearPlayer;
    public float delayAttack101;
    public float damageDealt;

    public int attack;

    public bool hasIdleRotation;
    public bool hpHasBeenSet;
    public bool rockHasSpawned;
    public bool damageDone;

    // Start is called before the first frame update
    void Start()
    {
        attack = 0;
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.speed = speedGolem;
        goal = spawner.GetComponent<Spawner>().player;
    }

    // Update is called once per frame
    void Update()
    {
        //navigation, this makes the bat move towards the player
        targetDirection = goal.position - transform.position;
        pos = transform.position;
        float distance = Vector3.Distance(transform.position, goal.position);
        if (distance < attackRange && attackTimer <= 4)
        {
            direction = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
            NavMeshAgent agent = GetComponent<NavMeshAgent>();
            agent.destination = goal.position;
        }
        else
        {
            //idle, makes the bat move in random directions
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
            GetComponent<Transform>().Translate(idleMovement * Time.deltaTime * speedGolem);
        }

        //attacks
        attackTimer += Time.deltaTime;

        if (attackTimer >= 4 && distance <= attackRange)
        {
            if (distance < nearPlayer)
            {
                attack = Random.Range(1, 100);
                speedGolem = 0;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.speed = speedGolem;
                if (attack >= 1 && attack <= 50)
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit, 2))
                    {
                        damageDealt = spawner.GetComponent<Difficulty>().dmg * 10;
                        goal.GetComponent<HealtPoints>().hp -= damageDealt;
                        damageDone = true;
                    }
                }
                else if (attack >= 51 && attack <= 80)
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit, 1.5f))
                    {
                        damageDealt = spawner.GetComponent<Difficulty>().dmg * 12;
                        goal.GetComponent<HealtPoints>().hp -= damageDealt;
                        damageDone = true;
                    }
                }
                else
                {
                    if (Physics.Raycast(transform.position, Vector3.forward, out hit, 2.5f))
                    {
                        damageDealt = spawner.GetComponent<Difficulty>().dmg * 20;
                        goal.GetComponent<HealtPoints>().hp -= damageDealt;
                        damageDone = true;
                    }
                }
            }
            else
            {
                attack = 101;
                speedGolem = 0;
                NavMeshAgent agent = GetComponent<NavMeshAgent>();
                agent.speed = speedGolem;
                delayAttack101 += Time.deltaTime;
                if (delayAttack101 >= 0.5f && rockHasSpawned == false)
                {
                    rockPos.x = pos.x;
                    rockPos.y = pos.y + 1.5f;
                    rockPos.z = pos.z;
                    GameObject newRock = Instantiate(rock, rockPos, Quaternion.identity);
                    newRock.GetComponent<Rock>().player = goal;
                    newRock.GetComponent<Rock>().spawner = spawner;
                    rockHasSpawned = true;
                }

                if (rockHasSpawned == true)
                {
                    attack = 0;
                    attackTimer = 0;
                    rockHasSpawned = false;
                }
            }
        }
        else if (attackTimer >= 4 && distance >= attackRange)
        {
            attackTimer = 0;
        }

        //hp
        if (spawner.GetComponent<Difficulty>().hp != 0 && hpHasBeenSet == false)
        {
            hpHasBeenSet = true;
            GetComponent<enemyHPscript>().enemyHP = 50 + spawner.GetComponent<Difficulty>().hp * 5;
        }

        if (GetComponent<enemyHPscript>().enemyHP <= 0 && hpHasBeenSet == true)
        {
            print("golem died");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && damageDone == false)
        {
            if (attack >= 1 && attack <= 40)
            {
                
            }
        }
    }
}
