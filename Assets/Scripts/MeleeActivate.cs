using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeActivate : MonoBehaviour
{

    public GameObject abilityOne;
    public GameObject abilityTwo;
    void Start()
    {
        abilityOne.SetActive(true);
        //abilityOne.GetComponent<Button>().enabled = true;
        abilityTwo.SetActive(true);
        //abilityTwo.GetComponent<Button>().enabled = true;
    }


}
