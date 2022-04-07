using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    public float spawnDelayBat;
    public float spawnDelayGolem;
    public float spawnDelaySkeleton;

    public GameObject newBat;
    public GameObject newGolem;
    public GameObject newSkeleton;
    public GameObject spawner;

    public Transform player;

    public NavMeshHit spawnY;

    public Vector3 pos;
    public Vector3 newBatPos;
    public Vector3 newGolemPos;
    public Vector3 newSkeletonPos;

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
        spawnDelaySkeleton += Time.deltaTime;

        // bat spawn
        if (spawnDelayBat >= 15 - GetComponent<Difficulty>().difficultyMeter)
        {
            spawnDelayBat = 0;
            randomizePos();

            if (NavMesh.SamplePosition(pos, out spawnY, 500, 1))
            {
                newBatPos.x = pos.x;
                newBatPos.z = pos.z;
                newBatPos.y = spawnY.position.y;
                GameObject bat = Instantiate(newBat, newBatPos, Quaternion.identity);
                bat.GetComponent<BatAI>().spawner = spawner;
            }

            // golem spawn
            if (spawnDelayGolem >= 60 - GetComponent<Difficulty>().difficultyMeter && GetComponent<Difficulty>().difficultyMeter >= 5)
            {
                spawnDelayGolem = 0;
                randomizePos();

                if (NavMesh.SamplePosition(pos, out spawnY, 500, 1))
                {
                    newGolemPos.x = pos.x;
                    newGolemPos.z = pos.z;
                    newGolemPos.y = spawnY.position.y;
                    GameObject golem = Instantiate(newGolem, newGolemPos, Quaternion.identity);
                    golem.GetComponent<GolemAI>().spawner = spawner;
                }
            }

            // skeleton spawn
            if (spawnDelaySkeleton >= 60 - GetComponent<Difficulty>().difficultyMeter && GetComponent<Difficulty>().difficultyMeter >= 3)
            {
                spawnDelaySkeleton = 0;
                randomizePos();

                if (NavMesh.SamplePosition(pos, out spawnY, 500, 1))
                {
                    newSkeletonPos.x = pos.x;
                    newSkeletonPos.z = pos.z;
                    newSkeletonPos.y = spawnY.position.y;
                    GameObject skeleton = Instantiate(newSkeleton, newSkeletonPos, Quaternion.identity);
                    skeleton.GetComponent<SkeletonAI>().spawner = spawner;
                }
            }
        }
    }

    void randomizePos()
    {
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
    }
}
