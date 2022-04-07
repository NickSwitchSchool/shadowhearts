using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionPlayer : MonoBehaviour
{
    public int damage;
    public bool isAttacking;
    public float damageDelay;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
    //        other.gameObject.GetComponent<enemyHPscript>().enemyHP -= damage;
    //    }
    //}

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            damageDelay += Time.deltaTime;
            if (damageDelay >= 1)
            {
                damageDelay = 0;
                isAttacking = true;
            }
        }
    }
}