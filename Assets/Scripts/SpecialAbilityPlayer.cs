using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpecialAbilityPlayer : MonoBehaviour
{
    private GameObject players;

    private PhotonView photonView;
    void Awake()
    {
        players = GameObject.Find("Players");
        photonView = GetComponent<PhotonView>();
    }
    public void bigSwing()
    {
        if (gameObject.tag == "Melee")
        {
            gameObject.GetComponent<PlayerMovement>().bigSwingAttack(40);
        }

    }

    public void buffArmor()
    {
        if (photonView.IsMine && gameObject.tag == "Melee")
        {
            players = GameObject.Find("Players");
            for (int i = 0; i < players.transform.childCount; i++)
            {
                players.transform.GetChild(i).gameObject.GetComponent<Shift_Player>().updateArmorRPC(3);
            }
        }
    }

    public void bigShot()
    {
        if (gameObject.tag == "Range")
        {
            gameObject.GetComponent<PlayerMovement>().bigShotAttack(40);
        }
    }

    public void aoeHeal()
    {
        if (photonView.IsMine && gameObject.tag == "Range")
        {
            players = GameObject.Find("Players");
            for (int i = 0; i < players.transform.childCount; i++)
            {
                players.transform.GetChild(i).gameObject.GetComponent<Shift_Player>().updateHPRPC(25);
            }
        }
    }
}
