using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if(transform.position.y > 70 || transform.position.y < -55 || transform.position.x < -52 || transform.position.x > 55)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player 1") || collision.gameObject.CompareTag("Player 2")){
            Destroy(gameObject);
        }
    }
}
