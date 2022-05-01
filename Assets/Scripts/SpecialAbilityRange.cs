using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpecialAbilityRange : MonoBehaviour
{
    private GameObject players;

    private PhotonView photonView;
    void Awake(){
        players = GameObject.Find("Players");
        photonView = GetComponent<PhotonView>();
    }

    public void bigShot(){

    }

    public void aoeHeal(){
        if(photonView.IsMine && this.tag == "Range"){
        players = GameObject.Find("Players");
        for(int i = 0; i < players.transform.childCount; i++){
            players.transform.GetChild(i).gameObject.GetComponent<Shift_Player>().updateHPRPC(50);
        }
        }
    }
}
