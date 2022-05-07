using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMODUnity;

public class SpecialAbilities : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject melee;

    private GameObject range;

    public GameObject healanimator;

    public GameObject BigAttackAnimator;

    public GameObject armorUpAnimator;

      [SerializeField] EventReference audioHeal;

      [SerializeField] EventReference audioShield;  
    void Start(){
       melee = GameObject.FindWithTag("Melee");
   
       range =  GameObject.FindWithTag("Range");

       healanimator = GameObject.Find("HealUp");

       armorUpAnimator = GameObject.Find("ArmorUp");

       BigAttackAnimator = GameObject.Find("BigAttack");
       
    }
    public void HEAL(){
        if(range != null){
        range.GetComponent<SpecialAbilityPlayer>().aoeHeal();
        healanimator.GetComponent<HealPressController>().healAnimator();
         var audioEvent = RuntimeManager.CreateInstance(audioHeal);
            audioEvent.start();
            audioEvent.release();
        }
    }

    public void Armor(){
        if(melee != null){
        melee.GetComponent<SpecialAbilityPlayer>().buffArmor();
        armorUpAnimator.GetComponent<ArmorPressController>().ArmorUpAnimation();
             var audioEvent = RuntimeManager.CreateInstance(audioShield);
            audioEvent.start();
            audioEvent.release();
        }
    }

    public void Swing(){
        if(melee != null){
            BigAttackAnimator.GetComponent<BigSwingPressController>().BigSwingAnimation();
            melee.GetComponent<SpecialAbilityPlayer>().bigSwing();
        }

    }

     public void Shot(){
        if(range != null){
            range.GetComponent<SpecialAbilityPlayer>().bigShot();
        }

    }


}
