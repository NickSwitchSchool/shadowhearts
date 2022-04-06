using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollisionPlayer : MonoBehaviour
{
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
