using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPressController : MonoBehaviour{
    public Animator animation;
    // Start is called before the first frame update
    void Start(){
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void ArmorUpAnimation(){
     
            animation.Play("ArmorUp");
        
    }
}
