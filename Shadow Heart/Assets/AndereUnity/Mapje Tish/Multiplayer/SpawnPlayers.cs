using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerAndCamPrefab;

    public int clickedOnce;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerAndCamPrefab.name, randomPos, Quaternion.identity);
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            clickedOnce = 1;
            if (clickedOnce == 1)
            {
                photonView.gameObject.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
