using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private int damage;

    private float elapsedTime;

    void Start(){
        elapsedTime = 0f;

    }

    void Update(){
        elapsedTime+= Time.deltaTime;

        if(elapsedTime > 0.3f){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy"){
            collision.gameObject.GetComponent<Shift_AI>().takeDamageRPC(getDamage());
        }
        if(collision.gameObject.tag == "boss"){
            collision.gameObject.GetComponent<BossMechanics>().takeDamageRPC(getDamage());
        }
        Destroy(gameObject);
    }

    public int getDamage(){
        return damage;
    }
    public void setDamage(int damage){
       this.damage = damage;
    }
}
