using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;


    void Awake()
    {
        Vector2 randomPosition = new Vector2(11.52f, 0f);
       // PhotonNetwork.
       Instantiate(playerPrefab, randomPosition, Quaternion.identity);
    }
   
  
}
