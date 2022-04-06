using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatPlaceholder : MonoBehaviour
{
    public GameObject spawner;
    public GameObject newBat;
    public GameObject batPlaceholderObject;

    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = GetComponent<Transform>().position;
        if (GetComponent<Rigidbody>().velocity.y == 0)
        {
            GameObject bat = Instantiate(newBat, pos, Quaternion.identity);
            bat.GetComponent<BatPlaceholder>().spawner = spawner;
            Destroy(batPlaceholderObject);
        }
    }
}
