using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D Rb;
    public Animator animator;
    
    PhotonView view;

    Vector2 movement;
    public Vector2 lookDir;
    public Vector2 shootDir;

    private List<Vector2> BigSwingLookDir;

    private float elapsedTime;

    public GameObject arrow;

    public GameObject BigAttack;
    private void Start()
    {
        
        view = GetComponent<PhotonView>();
        elapsedTime = 0;
        BigSwingLookDir = new List<Vector2>(4);
    }


    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (view.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Space) && elapsedTime > 0.5f)
            {
                Attack(20);
                elapsedTime = 0;
            }


            //Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            //Running Animations
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);


            //Idle Animations
            if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1)
            {
                animator.SetFloat("lastMoveX", movement.x);
                animator.SetFloat("lastMoveY", movement.y);

                //Directional looking
                if (movement.x == 1)
                {
                    //Debug.Log("Looking right");
                    lookDir = new Vector2(transform.position.x + 1, transform.position.y);
                    shootDir = new Vector2(1, 0);
                }


                if (movement.x == -1)
                {
                    //Debug.Log("Looking left");
                    lookDir = new Vector2(transform.position.x - 1, transform.position.y);
                    shootDir = new Vector2(-1, 0);
                }


                if (movement.y == -1)
                {
                    //Debug.Log("Looking down");
                    lookDir = new Vector2(transform.position.x, transform.position.y - 1);
                    shootDir = new Vector2(0, -1);
                }


                if (movement.y == 1)
                {
                    //Debug.Log("Looking up");
                    lookDir = new Vector2(transform.position.x, transform.position.y + 1);
                    shootDir = new Vector2(0, 1);
                }



            }






        }


    }

    Vector2 getLookDir()
    {
        return lookDir;
    }

    void FixedUpdate()
    {
        if (view.IsMine)
        {
            //Movement

            Rb.MovePosition(Rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        }



    }

    public void bigSwingAttack(int damage)
    {

        animator.SetTrigger("Attack");
        

        //Spawn Sword attack
        BigSwingLookDir.Add(new Vector2(transform.position.x + 1, transform.position.y));
        BigSwingLookDir.Add(new Vector2(transform.position.x - 1, transform.position.y));
        BigSwingLookDir.Add(new Vector2(transform.position.x, transform.position.y - 1));
        BigSwingLookDir.Add(new Vector2(transform.position.x, transform.position.y + 1));

        for (int i = 0; i < BigSwingLookDir.Count; i++)
        {
            var swordattack = Instantiate(arrow, BigSwingLookDir[i], Quaternion.identity);
            swordattack.GetComponent<SwordAttack>().setDamage(damage);
        }
        BigSwingLookDir.Clear();

    }

    public void bigShotAttack(int damage)
    {
      
         animator.SetTrigger("Attack");
            var test = gameObject;
                test = PhotonNetwork.Instantiate(arrow.name, lookDir, Quaternion.identity);
                var testComponent =   test.gameObject.GetComponent<ProjectileController>();
                testComponent.BigArrow = true;
                testComponent.player = this.transform.gameObject;
                testComponent.damage = damage;
                test.gameObject.transform.parent= transform;
                test.gameObject.transform.localScale = test.gameObject.transform.localScale * 2;
                test.gameObject.GetComponent<BoxCollider2D>().size = test.gameObject.GetComponent<BoxCollider2D>().size * 2;
                
            

    }

    public void Attack(int damage)
    {

        if (gameObject.tag == "Range")
        {
            //Play attack animation
            animator.SetTrigger("Attack");

            //Special attack
            var test = gameObject;

            test = PhotonNetwork.Instantiate(arrow.name, lookDir, Quaternion.identity);
            test.gameObject.transform.parent = transform;
            var testComponent =  test.gameObject.GetComponent<ProjectileController>();
            testComponent.player = this.transform.gameObject;
            testComponent.damage = damage;


        }

        if (gameObject.tag == "Melee")
        {
            //Play attack animation
            animator.SetTrigger("Attack");

            //Spawn Sword attack
            var test = Instantiate(arrow, lookDir, Quaternion.identity);
            test.GetComponent<SwordAttack>().setDamage(damage);

        }


    }
}
