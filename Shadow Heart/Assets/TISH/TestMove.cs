using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float moveVelocity;
    public float dodgePower;
    public int timer;

    public float stamina;
    public bool input;

    public GameObject pluur;
    public Rigidbody playerRb;
    public bool grounded;
    public float jumpHeight;

    public float speed;
    public Transform cam;

    public float h;
    public float v;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        stamina = 100;
        playerRb = GetComponent<Rigidbody>();
    }
       
    public void Update()
    {
        if (view.IsMine)
        {
            //code voor bewegen
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(h, 0, v).normalized;
            move.x = h;
            move.z = v;

            pluur.transform.position += cam.transform.rotation * move * moveVelocity * Time.deltaTime;

            Debug.Log(move);

            Quaternion targetRotation = Quaternion.LookRotation(move);
            targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 420 * Time.deltaTime);

            playerRb.MoveRotation(targetRotation);

            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * cam.GetComponent<Koekie>().sensivity * Time.deltaTime);

            Quaternion CamRotation = cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
        }
        if (input == false && stamina <= 100)
        {
            stamina += Time.deltaTime;
        }

        if (grounded == true && stamina >= 0)
        {
            if (Input.GetButtonDown("Sprint"))
            {
                input = true;
                moveVelocity += 8;
                if (moveVelocity >= 15)
                {
                    stamina -= Time.deltaTime;
                }
            }

            if (Input.GetButtonUp("Sprint"))
            {
                input = false;
                moveVelocity -= 8;
            }
        }

        if (grounded == true && stamina >= 15)
        {
            if (Input.GetButtonDown("Jumping"))
            {
                input = true;
                stamina -= 15;
                playerRb.AddForce(Vector3.up * jumpHeight);
                grounded = false;
            }
            else
            {
                input = false;
            }
        }

        if (grounded == true && stamina >= 20)
        {
            if (Input.GetButtonDown("Dodge"))
            {
                input = true;
                stamina -= 20;
                playerRb.AddForce(transform.forward * dodgePower);
            }
            else
            {
                input = false;
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
