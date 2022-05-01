using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MouseOverButtons : MonoBehaviour
{
    public Sprite Highlighted;
    
    public Sprite notHighlighted;

    private Image imageComponenet;
    void Start(){

        imageComponenet = GetComponent<Image>();
        Debug.Log("RAN");
    }
    void OnMouseOver(){
        Debug.Log("MOUSE OVER");
        imageComponenet.overrideSprite = Highlighted;
    }
    
    void onMouseExit(){
          Debug.Log("MOUSE EXIT");
        imageComponenet.overrideSprite = notHighlighted;
    }
}
