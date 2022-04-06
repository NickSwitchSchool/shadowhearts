using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public float spawnDelayBat;
    public float spawnDelayGolem;

    public GameObject newBat;
    public GameObject newGolem;
    public GameObject spawner;

    public Transform player;

    public NavMeshHit spawnY;

    public Vector3 pos;
    public Vector3 newBatPos;

    // Start is called before the first frame update
    void Start()
    {
        pos.x = Random.Range(220f, 690f);
        pos.z = Random.Range(150f, 740f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelayBat += Time.deltaTime;
        spawnDelayGolem += Time.deltaTime;

        if (spawnDelayBat >= 15 - GetComponent<Difficulty>().difficultyMeter)
        {
            spawnDelayBat = 0;
            if (pos.x <= 200f)
            {
                pos.x += Random.Range(0, 20);
            }
            else if (pos.x >= 670f)
            {
                pos.x += Random.Range(-20, 0);
            }
            else
            {
                pos.x += Random.Range(-20, 20);
            }

            if (pos.z <= 130f)
            {
                pos.z += Random.Range(0, 20);
            }
            else if (pos.z >= 720f)
            {
                pos.z += Random.Range(-20, 0);
            }
            else
            {
                pos.z += Random.Range(-20, 20);
            }
            GetComponent<Transform>().position = pos;

            if (NavMesh.SamplePosition(pos, out spawnY, 500, 1))
            {
                newBatPos.x = pos.x;
                newBatPos.z = pos.z;
                newBatPos.y = spawnY.position.y;
                GameObject bat = Instantiate(newBat, newBatPos, Quaternion.identity);
                bat.GetComponent<BatAI>().spawner = spawner;
            }

            //GameObject bat = Instantiate(newBat, pos, Quaternion.identity);
            //bat.GetComponent<BatAI>().spawner = spawner;

            if (spawnDelayGolem >= 60 - GetComponent<Difficulty>().difficultyMeter && GetComponent<Difficulty>().difficultyMeter >= 5)
            {
                spawnDelayGolem = 0;
                if (pos.x <= 200f)
                {
                    pos.x += Random.Range(0, 20);
                }
                else if (pos.x >= 670f)
                {
                    pos.x += Random.Range(-20, 0);
                }
                else
                {
                    pos.x += Random.Range(-20, 20);
                }

                if (pos.z <= 130f)
                {
                    pos.z += Random.Range(0, 20);
                }
                else if (pos.z >= 720f)
                {
                    pos.z += Random.Range(-20, 0);
                }
                else
                {
                    pos.z += Random.Range(-20, 20);
                }
                GameObject golem = Instantiate(newGolem, pos, Quaternion.identity);
                golem.GetComponent<GolemAI>().spawner = spawner;
            }
        }
    }
}
