using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnEnemies;

    public GameObject startButton;

    // Update is called once per frame

    public void startGame(){

        this.GetComponentInChildren<PlayerMovement>().enabled = true;
        spawnEnemies.GetComponent<SpawnEnemies>().enabled = true;
        startButton.SetActive(false);


    }
}
