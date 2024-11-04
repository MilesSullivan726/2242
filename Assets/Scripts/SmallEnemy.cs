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
        direction = Random.Range(0, 2);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasReachedBottom == false)
        {
            rigidBody.AddForce(Vector3.down * Time.deltaTime * speed, ForceMode2D.Impulse);

            if (direction == 0 || transform.localPosition.x < -194)
            {
                rigidBody.AddForce(Vector3.right * Time.deltaTime * turnSpeed, ForceMode2D.Impulse);
                Debug.Log("0");
            }

            else if(direction == 1 || transform.localPosition.x > 194)
            {
                rigidBody.AddForce(Vector3.left * Time.deltaTime * turnSpeed, ForceMode2D.Impulse);
                Debug.Log("1");
            }
        }

        if(transform.localPosition.y < -216 || hasReachedBottom == true )
        {
            hasReachedBottom = true;
            rigidBody.AddForce(Vector3.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        if(transform.localPosition.y > 260)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {           
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}
