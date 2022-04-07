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
    public float distanceToClosestSword;
    public GameObject[] swords;
    public GameObject targetSword;


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

        distanceToClosestSword = 1234567890;
        swords = GameObject.FindGameObjectsWithTag("Sword");
        foreach (GameObject sword in swords)
        {
            float distance = Vector3.Distance(sword.GetComponent<Transform>().position, GetComponent<Transform>().position);
            if (distance <= distanceToClosestSword)
            {
                distanceToClosestSword = distance;
                targetSword = sword;
            }
        }
        swords = GameObject.FindGameObjectsWithTag("FireSword");
        foreach (GameObject sword in swords)
        {
            float distance = Vector3.Distance(sword.GetComponent<Transform>().position, GetComponent<Transform>().position);
            if (distance <= distanceToClosestSword)
            {
                distanceToClosestSword = distance;
                targetSword = sword;
            }
        }
        if (distanceToClosestSword <= 3 && targetSword.GetComponent<DamageOnCollisionPlayer>().isAttacking == true && targetSword.tag == "Sword")
        {
            enemyHP -= targetSword.GetComponent<DamageOnCollisionPlayer>().damage;
            targetSword.GetComponent<DamageOnCollisionPlayer>().isAttacking = false;
        }
        else if (distanceToClosestSword <= 3 && targetSword.GetComponent<DamageOnCollisionPlayer>().isAttacking == true && targetSword.tag == "FireSword")
        {
            enemyHP -= targetSword.GetComponent<DamageOnCollisionPlayer>().damage;
            targetSword.GetComponent<DamageOnCollisionPlayer>().isAttacking = false;
            onFire = true;
        }

    }
}
