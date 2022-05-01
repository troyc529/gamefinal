using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnEnemiesArea2 : MonoBehaviour
{
    public GameObject EnemyPrefab;

    public float secondsBetweenSpawn;
    public float elapsedTime = 20f;

    public int numSpawn;
    public int numEnemies;


    private Transform EnemyAI;


    private Vector3[] randomPos;


    public GameObject nextAreaCanvas;



    void OnEnable()
    {
        numEnemies = 0;
        EnemyAI = gameObject.transform;
        randomPos = new Vector3[2];

    }

    void Update()
    {
       
            elapsedTime += Time.deltaTime;
            if (elapsedTime > secondsBetweenSpawn && numSpawn > numEnemies)
            {
              //  count = Random.Range(0, 2);
                elapsedTime = 0;

                randomPos[0] = new Vector3(Random.Range(7, 23), Random.Range(30, 37), 0f);
               // randomPos[1] = new Vector3(Random.Range(6, 13), Random.Range(6, 9), 0f);
                //PhotonNetwork.Instantiate(EnemyPrefab.name, random, Quaternion.identity);
                var enemy = PhotonNetwork.InstantiateRoomObject(EnemyPrefab.name, randomPos[0], Quaternion.identity);
                //  enemy.gameObject.transform.position = random;
                enemy.gameObject.transform.parent = EnemyAI;
                numEnemies++;
            }

             if(numEnemies == numSpawn && transform.childCount == 0){
                nextAreaCanvas.GetComponent<nextAreaOpen>().areatrigger = true;
                this.enabled = false;
            }
        
    }




}
