using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player 1 inputs
    private float horizontalInputP1;
    private float verticalInputP1;
    private float lastShot = 0;
    private Rigidbody2D rigidBody;
    public GameObject prefab;
    public GameObject canvas;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player 1 inputs
        horizontalInputP1 = Input.GetAxis("Horizontal");
        verticalInputP1 = Input.GetAxis("Vertical");


        rigidBody.AddForce(Vector3.up * verticalInputP1 * Time.deltaTime * speed, ForceMode2D.Impulse);
        rigidBody.AddForce(Vector3.right * horizontalInputP1 * Time.deltaTime * speed, ForceMode2D.Impulse);

        //Keep player on screen
        //left and right bounds
        if (transform.localPosition.x < -194)
        {
            transform.localPosition = new Vector3(-194f, transform.localPosition.y, transform.localPosition.z);
        }

        else if (transform.localPosition.x > 194)
        {
            transform.localPosition = new Vector3(194, transform.localPosition.y, transform.localPosition.z);
        }

        //top and bottom bounds
        if (transform.localPosition.y < -203)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -203, transform.localPosition.z);
        }

        else if (transform.localPosition.y > 201)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 201, transform.localPosition.z);
        }

        //fire projectile
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastShot >= 0.1f)
        {
            lastShot = Time.time;
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.localRotation, canvas.transform);
        }

    }
}
