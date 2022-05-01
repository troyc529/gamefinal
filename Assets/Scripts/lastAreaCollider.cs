using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class lastAreaCollider : MonoBehaviour
{
    // Start is called before the first frame update

  
    public GameObject secondAreaMusic;

    public GameObject firstAreaMusic;


    

    void OnTriggerEnter2D(Collider2D Collision){

        if(Collision.tag == "Melee" || Collision.tag == "Range"){
             
        firstAreaMusic.gameObject.SetActive(false);
        secondAreaMusic.gameObject.SetActive(true);
        gameObject.SetActive(false);
        }

    }
}
