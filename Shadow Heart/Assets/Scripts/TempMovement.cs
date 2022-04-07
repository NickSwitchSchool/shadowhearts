using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{
    public float movementX;
    public float movementZ;
    public float movespeed;

    public Vector3 movement;
    public Vector3 direction;

    public Transform cam;

    // Update is called once per frame
    void Update()
    {
        movementX = -Input.GetAxis("Horizontal");
        movementZ = -Input.GetAxis("Vertical");
        movement.x = movementX;
        movement.z = movementZ;

        transform.Translate(movement * Time.deltaTime * movespeed);


        direction.x = cam.GetComponent<Transform>().position.x;
        direction.z = cam.GetComponent<Transform>().position.z;
        direction.y = transform.position.y;
        transform.LookAt(direction);
    }
}
