using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
     private DoorControl door;
    // Start is called before the first frame update
   
    // Update is called once per frame

    void Start(){
    door = GameObject.FindWithTag("Door").GetComponent<DoorControl>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            Debug.Log("OPENED DOOR");
            door.OpenDoor();
        }
    }
}
