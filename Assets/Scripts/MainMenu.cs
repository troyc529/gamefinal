using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject loading;

    public void gameEnter(){

        gameObject.SetActive(false);
        loading.SetActive(true);

    }

    public void gameExit(){
        
        Application.Quit();

    }
    
}
