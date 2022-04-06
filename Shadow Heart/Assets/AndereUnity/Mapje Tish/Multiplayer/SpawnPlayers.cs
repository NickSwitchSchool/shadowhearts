using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SpawnPlayers : MonoBehaviourPunCallbacks
{
    public GameObject playerAndCamPrefab;
    public GameObject spawningPlayer;   

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minZ;
    public float maxZ;

    public float howMany;

    public string[] players = { "player1", "player2", "player3", "player4" };

    public void Start()
    {
        howMany = 0;
    }

    public void onButtonClick()  
    {
        foreach(string i in players)
        {
            print("player spawned");
            if (howMany == 5)
            {
                print("Lobby is full!");
            }

            howMany += 0.25f;
        }
                
        if(howMany >= 4)
        {
            Vector3 randomPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));

            PhotonNetwork.Instantiate(playerAndCamPrefab.name, randomPos, Quaternion.identity);

            //spawningPlayer.SetActive(false);
        }
    }
}
