using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerActivate : MonoBehaviour
{

    public GameObject abilityOne;
    public GameObject abilityTwo;
    void Start()
    {
        abilityOne.SetActive(true);
        abilityTwo.SetActive(true);
    }


}