using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    public int speed;
    public int turnSpeed;
    private bool hasReachedBottom = false;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        //randomly choose to move left or right
        direction = Random.Range(0, 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the enemy has not reached the bottom of the screen, move down and left or right
        if (hasReachedBottom == false)
        {
            rigidBody.AddForce(Vector3.down * Time.deltaTime * speed, ForceMode2D.Impulse);

            if (direction == 0 && transform.localPosition.x < 194)
            {
                rigidBody.AddForce(Vector3.right * Time.deltaTime * turnSpeed, ForceMode2D.Impulse);
                
            }
            //if enemy hits right border, change direction to left
            else if(direction == 0 && transform.localPosition.x > 194)
            {
                direction = 1;
            }

            if(direction == 1 && transform.localPosition.x > -194)
            {
                rigidBody.AddForce(Vector3.left * Time.deltaTime * turnSpeed, ForceMode2D.Impulse);
               
            }
            //if enemy hits left border, change direction to right
            else if (direction == 1 && transform.localPosition.x < -194)
            {
                direction = 0;
            }
        }

        //if the enemy reaches the bottom, move back up
        if(transform.localPosition.y < -216 || hasReachedBottom == true)
        {
            hasReachedBottom = true;
            rigidBody.AddForce(Vector3.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        //if the enemy reaches the bottom and moves all the way back up without being destroyed, destroy it
        if(transform.localPosition.y > 260)
        {
            Destroy(gameObject);
        }
    }

    //if the enemy is hit by a player or projectile, destroy it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.Find("Point Manager").GetComponent<PointManager>().UpdatePoints(100);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.CompareTag("Player 1") || collision.gameObject.CompareTag("Player 2"))
        {
            Destroy(gameObject);
        }
    }

}
