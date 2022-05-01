using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnableDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PdUI;

   public void enableDeathUI(){

       PdUI.SetActive(true);
  
   }
}
