using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    //Populates the selected units name
    public string unitName;
    public int unitLevel;

    // Declares their individual hit points.
    public int maxHP;
    // Their given attack power this is how much they will damage whatever they are attacking.
    public int attackPower;
    // Their given defense and how much of opposing attack power they resist.
    public int defenseRating;
    // How many tiles they can attack from. 
    public int attackRange;
}
