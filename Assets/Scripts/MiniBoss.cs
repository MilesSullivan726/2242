using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBoss : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    public int speed;
    public int turnSpeed;
    private bool hasReachedBottom = false;
    private int direction;
    private int health = 3;
    private Image flash;
    public GameObject projectile;
    private GameObject canvas;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        //randomly choose to move left or right
        direction = Random.Range(0, 2);
        flash = gameObject.GetComponent<Image>();
        InvokeRepeating("SpawnProjectile", 0, 1);

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
            else if (direction == 0 && transform.localPosition.x > 194)
            {
                direction = 1;
            }

            if (direction == 1 && transform.localPosition.x > -194)
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
        if (transform.localPosition.y < -216 || hasReachedBottom == true)
        {
            hasReachedBottom = true;
            rigidBody.AddForce(Vector3.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        //if the enemy reaches the bottom and moves all the way back up without being destroyed, destroy it
        if (transform.localPosition.y > 280)
        {
            Destroy(gameObject);
        }
    }

    //if the enemy is hit by a player or projectile, destroy it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayHurtSFX();
            health -= 1;
            Destroy(collision.gameObject);
            StartCoroutine(FlashOnHit());
            if (health <= 0)
            {
                Instantiate(explosion, transform.position, transform.localRotation);
                GameObject.Find("Point Manager").GetComponent<PointManager>().UpdatePoints(300);
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        /*
        else if (collision.gameObject.CompareTag("Player 1") || collision.gameObject.CompareTag("Player 2"))
        {
            Destroy(gameObject);
        }*/
    }

    private void SpawnProjectile()
    {
        GameObject.Find("Audio Manager").GetComponent<AudioManager>().PlayProjectile();

        Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - 10, transform.position.z), Quaternion.Euler(0f, 0f, 180f), canvas.transform);
    }

    IEnumerator FlashOnHit()
    {
        flash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        flash.enabled = false;
    }
}
