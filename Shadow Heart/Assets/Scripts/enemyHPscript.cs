using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHPscript : MonoBehaviour
{
    public float enemyHP;
    public float fireTick;
    public float timeOnFire;
    public bool onFire;
    public bool particlesExist;
    public GameObject fireParticles;


    // Update is called once per frame
    void Update()
    {
        if (onFire == true && particlesExist == false)
        {
            GameObject clone = (GameObject)Instantiate(fireParticles, GetComponent<Transform>().position, Quaternion.identity);
            Destroy(clone, 8.0f);
            particlesExist = true;
        }


        if (onFire == true)
        {
            fireTick += Time.deltaTime;
            timeOnFire += Time.deltaTime;

            if (fireTick >= 1)
            {
                fireTick = 0;
                enemyHP -= 1;
            }
            if (timeOnFire >= 8)
            {
                onFire = false;
                timeOnFire = 0;
                fireTick = 0;
            }
        }
        else
        {
        }
    }
}
