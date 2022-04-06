using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    public GameObject player;

    public Text closestEnemy;

    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = 2000;
        var objects = GameObject.FindGameObjectsWithTag("Enemy");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            if (Vector3.Distance(obj.GetComponent<Transform>().position, player.GetComponent<Transform>().position) <= distance)
            {
                distance = Vector3.Distance(transform.position, player.GetComponent<Transform>().position);
            }
        }
        closestEnemy.text = "closest enemy: " + distance.ToString();
    }
}
