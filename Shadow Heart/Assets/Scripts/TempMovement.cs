using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// movement script is van een ouder project en is tijdelijk
public class TempMovement : MonoBehaviour
{
    public float leftRight;
    public float forwardBackward;
    public float moveSpeed;
    public float fps;

    public string deathMessage;

    public bool alive;

    public Vector3 pos;
    public Vector3 respawnPos;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 0.03f;
        alive = true;
        print("Setup complete");
    }

    // Update is called once per frame
    void Update()
    {
        // fps
        fps = 1 / Time.deltaTime;

        // Movement
        leftRight = Input.GetAxis("Horizontal");
        forwardBackward = Input.GetAxis("Vertical");
        pos.x = leftRight;
        pos.z = forwardBackward;
        GetComponent<Transform>().position += pos * moveSpeed / fps * 128;

        // Some debug stuff

        if (Input.GetKeyDown("p"))
        {
            print(GetComponent<Transform>().position);
        }

        if (Input.GetKeyDown("o"))
        {
            print(moveSpeed);
        }

        if (Input.GetKeyDown("f"))
        {
            print(fps);
        }
    }

    private void OnCollisionEnter(Collision colInfo)
    {
        // Collission with bomb
        if(colInfo.gameObject.name == "Bomb(Clone)")
        {
            deathMessage = "You exploded";
        }

        // Collission with boost
        if (colInfo.gameObject.name == "Boost(Clone)")
        {
            moveSpeed *= 2;
            print("Boost enabled, movespeed is now " + moveSpeed);
        }

        // Collission with deboost
        if (colInfo.gameObject.name == "Deboost(Clone)")
        {
            moveSpeed /= 2;
            print("Deboost enabled, movespeed is now " + moveSpeed);
        }
    }
}
