using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject camPlayer;

    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float minY;
    public float maxY;

    private void OnLevelWasLoaded(int level)
    {
        if(level == 2)
        {
            Instantiate(playerPrefab);

            Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), Random.Range(minY, maxY));

            PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
            PhotonNetwork.Instantiate(camPlayer.name, randomPos, Quaternion.identity);
        }
    }
}
