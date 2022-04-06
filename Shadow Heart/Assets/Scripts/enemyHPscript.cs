using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHPscript : MonoBehaviour
{
    public float enemyHP;

    public GameObject spawner;

    public bool hpHasBeenSet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //hp
        if (spawner.GetComponent<Difficulty>().hp != 0 && hpHasBeenSet == false)
        {
            hpHasBeenSet = true;
            enemyHP = spawner.GetComponent<Difficulty>().hp;
        }
    }
}
