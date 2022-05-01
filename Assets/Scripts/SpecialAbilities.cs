using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbilities : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject melee;

    private GameObject range;

    void Start(){
       melee = GameObject.FindWithTag("Melee");
   
       range =  GameObject.FindWithTag("Range");
       
    }
    public void HEAL(){
        if(range != null){
        range.GetComponent<SpecialAbilityPlayer>().aoeHeal();
        }
    }

    public void Armor(){
        if(melee != null){
        melee.GetComponent<SpecialAbilityPlayer>().buffArmor();
        }
    }

    public void Swing(){
        if(melee != null){
            melee.GetComponent<SpecialAbilityPlayer>().bigSwing();
        }

    }

     public void Shot(){
        if(range != null){
            range.GetComponent<SpecialAbilityPlayer>().bigShot();
        }

    }


}
