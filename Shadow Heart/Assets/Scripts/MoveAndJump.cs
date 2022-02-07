using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndJump : MonoBehaviour
{
    public float moveVelocity;

    public Rigidbody playerRb;
    public bool grounded;
    public float jumpHeight;


    public void Update()
    {
        //code voor bewegen
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3();
        move.x = h;
        move.z = v;

        transform.Translate(move * moveVelocity * Time.deltaTime);

        if (Input.GetButtonDown("Sprint"))
        {
            moveVelocity += 8;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            moveVelocity -= 8;
        }

        if (grounded == true)
        {
            if (Input.GetButtonDown("Jumping"))
            {
                playerRb.AddForce(Vector3.up * jumpHeight);
            }
        }
    }

    public void OnCollisionEnter(Collision Ground)
    {
        if (Ground.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
