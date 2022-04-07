using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionEnemy : MonoBehaviour
{
    public int damage;
    public GameObject skeleton;
    private void OnTriggerEnter(Collider other)
    {
        if (skeleton.GetComponent<SkeletonAI>().isAttacking == true)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<HealtPoints>().hp -= damage;
            }
        }
    }
}
