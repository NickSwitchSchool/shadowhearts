using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float h;
    public float v;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        //code voor bewegen
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3();
        move.x = h;
        move.z = v;

        transform.Translate(move * speed * Time.deltaTime);
    }
}
