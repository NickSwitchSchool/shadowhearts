using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnDelay;

    public GameObject newBat;
    public GameObject spawner;

    public Transform player;

    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos.x = Random.Range(220f, 690f);
        pos.z = Random.Range(150f, 740f);
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay += Time.deltaTime;

        if (spawnDelay >= 15 - GetComponent<Difficulty>().difficultyMeter)
        {
            spawnDelay = 0;
            if (pos.x <= 200f)
            {
                pos.x += Random.Range(0, 20);
            }
            else if  (pos.x >= 670f)
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
            GameObject bat = Instantiate(newBat, pos, Quaternion.identity);
            bat.GetComponent<BatAI>().spawner = spawner;
        }
    }
}
