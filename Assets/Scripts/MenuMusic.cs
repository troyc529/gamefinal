using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    private static FMOD.Studio.EventInstance Music;
    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/Assets/music/Forest-Defenders-Menu");
        Music.start();
        Music.release();
        
    }

  
}