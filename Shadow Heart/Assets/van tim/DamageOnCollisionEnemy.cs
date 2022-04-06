using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionEnemy : MonoBehaviour
{
    public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<HealtPoints>().hp -= damage;
        }
    }
}
