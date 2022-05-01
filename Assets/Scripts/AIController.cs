using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 target;

    private Transform players;
    void Start()
    {
        players = GameObject.Find("Players").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
