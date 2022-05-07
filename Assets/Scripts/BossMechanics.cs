using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using FMODUnity;
public class BossMechanics : MonoBehaviour
{

    private GameObject parentPosition;
    private PhotonView photonView;
    Vector2 movement;
    public int HP;
    public Rigidbody2D m_Rigidbody;
    public Vector2 lookDir;
    public Vector2 shootDir;
     private BoxCollider2D collider;

     public Text HPTEXT;
    
    private float elapsedTime = 10f;

    private float secondsBetweenSpawn;
    private float DeathTime;

       public Animator animator;

    public GameObject bossAttack;

    public GameObject playerVictory;

     [SerializeField] EventReference audioHit;

    void Awake()
    {
        collider = gameObject.GetComponent<BoxCollider2D>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
      //  this.gameObject.transform.parent = GameObject.Find("EnemyAI").transform;
        photonView = this.GetComponent<PhotonView>();
        Physics2D.IgnoreLayerCollision(10, 14);
        secondsBetweenSpawn = 2.5f;
        playerVictory = GameObject.Find("UI");
    }



    void Update()
    {
        updateHPTEXT();


             elapsedTime += Time.deltaTime;
            if (elapsedTime > secondsBetweenSpawn)
            {
         
                elapsedTime = 0;

                //PhotonNetwork.Instantiate(EnemyPrefab.name, random, Quaternion.identity);
                var enemy = PhotonNetwork.InstantiateRoomObject(bossAttack.name, transform.position, Quaternion.identity);
                enemy.transform.parent = gameObject.transform.parent;
                //  enemy.gameObject.transform.position = random;
             
                
            }
            
        if (HP <= 0)
        {
            DeathTime += Time.deltaTime;
            collider.enabled = false;
           // animator.SetTrigger("Death");
             var audioEvent = RuntimeManager.CreateInstance(audioHit);
            audioEvent.start();
            audioEvent.release();
            playerVictory.GetComponent<UIEnableDeath>().enablePlayerWinUI();
            if(DeathTime > .5f ){
                Destroy(gameObject);
            }
            //Destroy(gameObject);
        }

        //Input
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        // //Running Animations
        // animator.SetFloat("Horizontal", movement.x);
        // animator.SetFloat("Vertical", movement.y);
        // animator.SetFloat("speed", movement.sqrMagnitude);

        //Idle Animations
 

            // //Directional looking
            // if (movement.x == 1)
            // {
            //     //Debug.Log("Looking right");
            //     lookDir = new Vector2(transform.position.x + 1, transform.position.y);
            //     shootDir = new Vector2(1, 0);
            // }


            // if (movement.x == -1)
            // {
            //     //Debug.Log("Looking left");
            //     lookDir = new Vector2(transform.position.x - 1, transform.position.y);
            //     shootDir = new Vector2(-1, 0);
            // }


            // if (movement.y == -1)
            // {
            //     //Debug.Log("Looking down");
            //     lookDir = new Vector2(transform.position.x, transform.position.y - 1);
            //     shootDir = new Vector2(0, -1);
            // }


            // if (movement.y == 1)
            // {
            //     //Debug.Log("Looking up");
            //     lookDir = new Vector2(transform.position.x, transform.position.y + 1);
            //     shootDir = new Vector2(0, 1);
            // }
           

        
    }

    // public void destroyNetworkObjRPC()
    // {

    //     photonView.RPC(nameof(destroyNetworkObj), RpcTarget.All);
    // }

    // [PunRPC]
    // private void destroyNetworkObj()
    // {

    //     Destroy(gameObject);

    // }

    public void takeDamageRPC(int damage)
    {
        photonView.RPC(nameof(takeDamage), RpcTarget.AllBuffered, new object[] { damage });
    }

    [PunRPC]
    private void takeDamage(int damage)
    {

        HP -= damage;
        Debug.Log(damage);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("COLLISION!!!!");
        if (collision.gameObject.tag == "Range" || collision.gameObject.tag == "Melee")
        {
            collision.gameObject.GetComponent<Shift_Player>().takeDamageRPC(10);
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log("COLLISION!!!!");
        if (collision.gameObject.tag == "Range" || collision.gameObject.tag == "Melee")
        {
            collision.gameObject.GetComponent<Shift_Player>().takeDamageRPC(10);
        }

    }

      private void updateHPTEXT()
    {
        HPTEXT.text = HP.ToString();
    }


    //   public void updateArmorRPC(int num){
    //    photonView.RPC(nameof(updateArmor), RpcTarget.All, new object[]{num});
    //  }

    //   [PunRPC]
    //  private void updateArmor(int num){
    //    Armor +=num;
    //    if(Armor > 10){
    //      Armor = 10;
    //    }
    //  }

    //  public void updateHPARMORRPC(){
    //    photonView.RPC(nameof(updateARMORTEXT), RpcTarget.All);
    //  }

    //   [PunRPC]
    //  private void updateARMORTEXT(){
    //    ArmorText.text = Armor.ToString();
    //  }

    //  public void updateHPTEXTRPC(){
    //    photonView.RPC(nameof(updateHPTEXT), RpcTarget.All);
    //  }



    //  public void updateHPRPC(int num){
    //    photonView.RPC(nameof(updateHP), RpcTarget.All, new object[]{num});
    //  }

    //   [PunRPC]



}
