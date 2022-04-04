using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerAndCamPrefab;
    public GameObject spawningPlayer;   

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    public void onButtonClick()
    {
        Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

        PhotonNetwork.Instantiate(playerAndCamPrefab.name, randomPos, Quaternion.identity);

        spawningPlayer.SetActive(false);
    }
}
