using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnableDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PdUI;

    public GameObject PvUI;

    public GameObject exitUI;
   public void enableDeathUI(){

       PdUI.SetActive(true);
       exitUI.SetActive(true);
  
   }

   public void enablePlayerWinUI(){


       PvUI.SetActive(true);
        exitUI.SetActive(true);

   }
}
