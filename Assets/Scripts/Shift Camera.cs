using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiftCamera : MonoBehaviour
{
    public GameObject camera1;

    void start(){
        camera1.transform.position = new Vector3(11.37f, 0, -10f);

    }
}
