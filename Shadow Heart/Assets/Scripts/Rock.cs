using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Transform player;

    public Vector3 beingTrown;
    public bool isTrown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrown == false)
        {
            //beingTrown.x = Mathf.Abs(player.transform.position.x - transform.position.x);
            //beingTrown.y = 3;
            //beingTrown.z = Mathf.Abs(player.transform.position.z - transform.position.z);
            //GetComponent<Rigidbody>().velocity = beingTrown;
            Vector3 direction = player.transform.position - transform.position;
            GetComponent<Rigidbody>().velocity = direction * Random.Range(2f , 3.6f);
            isTrown = true;
        }
    }
}