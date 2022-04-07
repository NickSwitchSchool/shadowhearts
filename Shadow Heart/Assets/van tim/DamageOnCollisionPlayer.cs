using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionPlayer : MonoBehaviour
{
    public int damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetButtonDown("fire1"))
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<enemyHPscript>().enemyHP -= damage;
            }
        }
    }
}