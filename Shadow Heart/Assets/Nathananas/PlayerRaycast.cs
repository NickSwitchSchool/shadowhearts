using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject textLock;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        RaycastHit hitInfo;
        

        if(Physics.Raycast(transform.position, transform.forward, out hitInfo,1000))
        {
            print("hit object"); 
        }

        if(Physics.Raycast(transform.position, transform.forward, out hit, 5))
        {
            if(hit.transform.gameObject.tag == "Lock")
            {
                if(Input.GetButtonDown("Interact"))
                {
                    print("hit Lock");
                    //GetComponent<CameraSwitch>(CamSwitch); 
                }
            }
        }
    }
}
