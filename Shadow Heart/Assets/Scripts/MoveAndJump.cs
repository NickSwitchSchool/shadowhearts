using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndJump : MonoBehaviour
{
    public float moveVelocity;
    public float dodgePower;
    public int timer;

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

        //tijd dat je niet kan springen of rennen maar het werkt nog niet helemaal
        if (Input.GetButtonDown("Dodge"))
        {
            timer--;
        }

        if (timer <= 0)
        {
            timer = 1;
        }

        //code dat je kan rennen en NIET in de lucht kan rennen 
        if (grounded == true)
        {
            if (Input.GetButtonDown("Sprint"))
            {
                moveVelocity += 8;
            }
            if (Input.GetButtonUp("Sprint"))
            {
                moveVelocity -= 8;
            }
        }

        //code dat je kan springen wanneer je op de grond staat en ook NIET aan het dodgen bent
        if (grounded == true && timer == 1)
        {
            if (Input.GetButtonDown("Jumping"))
            {
                playerRb.AddForce(Vector3.up * jumpHeight);
                grounded = false;
            }
        }

        //code voor als je op de grond staat dat je kan dodgen en dat je niet in de lucht kan dodgen
        if (grounded == true)
        {
            if (Input.GetButtonDown("Dodge"))
            {
                playerRb.AddForce(transform.forward * dodgePower);
            }
        }
    }

    //code dat de bool grounded op true gaat als je op iets staat met tag grond
    public void OnCollisionEnter(Collision Ground)
    {
        if (Ground.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
