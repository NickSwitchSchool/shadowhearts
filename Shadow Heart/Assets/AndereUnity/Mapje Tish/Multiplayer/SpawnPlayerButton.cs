using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerButton : MonoBehaviour
{
    public GameObject waitCam;
    public GameObject uiSpawnButton;

    public GameObject player;
    public Vector3 spawner;

    // Start is called before the first frame update
    void Start()
    {
        waitCam.SetActive(true);
        uiSpawnButton.SetActive(true);  
    }

    public void SpawnPlayerUiButton()
    {
        Instantiate(player, spawner, Quaternion.identity);

        waitCam.SetActive(false);
        uiSpawnButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
