using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestOpenPlayer : MonoBehaviour
{
    public Animator chestOpen;
    public bool isOpen = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("E"))
            {
                isOpen = true;
                chestOpen.SetBool("isOpen", isOpen);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
