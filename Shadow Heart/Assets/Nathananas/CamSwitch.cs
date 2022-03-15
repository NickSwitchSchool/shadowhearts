using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{
    public bool toggle = true;
    public GameObject cam1;
    public GameObject cam2;

    void Start()
    {
        cam2.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown("v"))
        {
            if(toggle == true)
            {
                cam2.SetActive(true);
                cam1.SetActive(false);
                toggle = false;
            }
            else if(toggle == false)
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
                toggle = true;
            }
        }
    }
    public void CameraSwitch()
    {
        toggle = true;
        cam2.SetActive(false);
        
        if(toggle == true)
            {
                cam2.SetActive(true);
                cam1.SetActive(false);
                toggle = false;
            }
            else if(toggle == false)
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
                toggle = true;
            }
    }
}
