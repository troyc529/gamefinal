using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class miniArrowProjectile : MonoBehaviour
{
    public float speed;
    public float timeToLive;

    public int damage;

    Vector2 moveVector;

    public Vector2 playerDir;


    // Controls the projectile's velocity and call for collision.
    void Start()
    {
        Debug.Log("MINIARROW");
        moveVector = playerDir * Time.fixedDeltaTime;
        Physics2D.IgnoreLayerCollision(10, 10);

    

        if (playerDir.x == 1)
        {
            transform.localRotation = new Quaternion(90, 90, 0, 0);
        }
        if (playerDir.x == -1)
        {
            Debug.Log("Firing left");
            transform.localRotation = new Quaternion(90, 90, 0, 0);
            transform.localScale = new Vector2(-transform.localScale.x, -transform.localScale.y);
        }
        if (playerDir.y == 1)
        {

            transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
        }
        if (playerDir.y == -1)
        {

            transform.localScale = new Vector2(transform.localScale.x, -transform.localScale.y);
        }


    }


    // Moves the projectile.
    void FixedUpdate()
    {


        if (playerDir.x == 1)
        {
            // m_Rigidbody.AddForce(new Vector2(1, 0));
            gameObject.transform.position = new Vector2(transform.position.x+0.1f, transform.position.y);
        }
        if (playerDir.x == -1)
        {
            gameObject.transform.position = new Vector2(transform.position.x-0.1f, transform.position.y);
            // m_Rigidbody.AddForce(new Vector2(-1, 0));
        }
        if (playerDir.y == 1)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y+0.1f);
            // m_Rigidbody.AddForce(new Vector2(0, 1));
        }
        if (playerDir.y == -1)
        {
            gameObject.transform.position = new Vector2(transform.position.x, transform.position.y-0.1f);
            // m_Rigidbody.AddForce(new Vector2(0, -1));
        }

    }

    // Destroys prjectile upon collision.
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Shift_AI>().takeDamageRPC(damage);
        }
     
        // if (gameObject.GetComponent<BoxCollider2D>().size.x > ToSingle(.1))
        // {

        //     DestroyBlast();
        // }
        // else
        // {
           // Destroy(gameObject);
        // }


    }

 
    // Destroys projectile after a certain amount of time to reduce memory sink.
 



}


