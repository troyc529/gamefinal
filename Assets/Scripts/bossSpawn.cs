using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bossSpawn : MonoBehaviour
{
    // Start is called before the first frame update

  

    public GameObject bossPrefab;

    public GameObject EnemyAI;
    

    void OnTriggerEnter2D(Collider2D Collision){

        if(Collision.tag == "Melee" || Collision.tag == "Range"){
    
        var test =    PhotonNetwork.InstantiateRoomObject(bossPrefab.name, new Vector3(12.09f,60f,0),Quaternion.identity);
        test.gameObject.transform.parent = EnemyAI.transform;
        
        gameObject.SetActive(false);
        }

    }
}
