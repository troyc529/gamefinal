using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }


    void Attack()
    {
        //Play attack animation
        animator.SetTrigger("Attack");


        //Detect enemies in range of attack
        



        //Damage them



        
    }
}
