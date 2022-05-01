using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class nextAreaCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject EnemyAI;
    public GameObject secondAreaMusic;

    public GameObject firstAreaMusic;

    

    void OnTriggerEnter2D(Collider2D Collision){

        if(Collision.tag == "Melee" || Collision.tag == "Range"){
        EnemyAI.gameObject.GetComponent<SpawnEnemiesArea2>().enabled = true;
        firstAreaMusic.gameObject.SetActive(false);
        secondAreaMusic.gameObject.SetActive(true);
        gameObject.SetActive(false);
        }

    }
}
