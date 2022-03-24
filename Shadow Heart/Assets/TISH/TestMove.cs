using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public float h;
    public float v;
    public int speed;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
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
}
