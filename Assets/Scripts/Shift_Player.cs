using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Shift_Player : MonoBehaviour
{

    private GameObject parentPosition;

    private PhotonView photonView;

    public int HP;

    public Text HPTEXT;

    public Text ArmorText;

    private GameObject pDeath;

    public int Armor;

    private float elapsedTime;

    void Awake()
    {
        elapsedTime = 0f;
        this.gameObject.transform.parent = GameObject.Find("Players").transform;
        photonView = this.GetComponent<PhotonView>();
        float firstDigit = (float)(photonView.ViewID.ToString()[0]) - 48;
        this.gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(11.52f, firstDigit + 2f));
        this.gameObject.transform.position = new Vector3(11.52f, firstDigit + 2f, 0f);
        Physics2D.IgnoreLayerCollision(10, 11);
        pDeath = GameObject.Find("UI");

    }


    void Update()
    {
        elapsedTime+= Time.deltaTime;
        updateHPTEXT();
        updateARMORTEXT();
        playerDeathRPC();

    }




    public void playerDeathRPC(){

        photonView.RPC(nameof(playerDeath), RpcTarget.AllBuffered);
    }
    [PunRPC]
    private void playerDeath(){
        if(HP <= 0){
            Debug.Log("PLayer Dead");
             if(photonView.IsMine){
           pDeath.GetComponent<UIEnableDeath>().enableDeathUI();
             }
            gameObject.SetActive(false);
        }

    }
        public void takeDamageRPC(int damage)
    {
        photonView.RPC(nameof(takeDamage), RpcTarget.AllBuffered, new object[]{damage});
    }


    [PunRPC]
    private void takeDamage(int damage)
    {
        if(elapsedTime > 1f){
            elapsedTime = 0f;
        if(Armor > 0){
            Armor -= 1;
        }
        else{
        HP -= damage;
        }
        }
    

    }

    public void updateArmorRPC(int num)
    {
        photonView.RPC(nameof(updateArmor), RpcTarget.AllBuffered, new object[] { num });
    }

    [PunRPC]
    private void updateArmor(int num)
    {
        Armor += num;
        if (Armor > 10)
        {
            Armor = 10;
        }
    }

    //  public void updateHPARMORRPC(){
    //    photonView.RPC(nameof(updateARMORTEXT), RpcTarget.All);
    //  }

    [PunRPC]
    private void updateARMORTEXT()
    {
        ArmorText.text = Armor.ToString();
    }

    //  public void updateHPTEXTRPC(){
    //    photonView.RPC(nameof(updateHPTEXT), RpcTarget.All);
    //  }

   // [PunRPC] RECENT CHANGE
    private void updateHPTEXT()
    {
        HPTEXT.text = HP.ToString();
    }

    public void updateHPRPC(int num)
    {
        photonView.RPC(nameof(updateHP), RpcTarget.AllBuffered, new object[] { num });
    }

    [PunRPC]
    private void updateHP(int num)
    {
        HP += num;
        if (HP > 100)
        {
            HP = 100;
        }
    }



}
