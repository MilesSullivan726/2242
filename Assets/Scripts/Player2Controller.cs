using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    //player 2 inputs
    private float horizontalInputP2;
    private float verticalInputP2;
    private float lastShot = 0;
    private Rigidbody2D rigidBody;
    public GameObject prefab;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player 2 inputs
        horizontalInputP2 = Input.GetAxis("Horizontal2");
        verticalInputP2 = Input.GetAxis("Vertical2");

        rigidBody.AddForce(Vector3.up * verticalInputP2 * Time.deltaTime * 7000);
        rigidBody.AddForce(Vector3.right * horizontalInputP2 * Time.deltaTime * 7000);

        //Keep player on screen
        //left and right bounds
        if (transform.localPosition.x < -196)
        {
            transform.localPosition = new Vector3(-196f, transform.localPosition.y, transform.localPosition.z);
        }

        else if (transform.localPosition.x > 195)
        {
            transform.localPosition = new Vector3(195, transform.localPosition.y, transform.localPosition.z);
        }

        //top and bottom bounds
        if (transform.localPosition.y < -205)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, -205, transform.localPosition.z);
        }

        else if (transform.localPosition.y > 202)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, 202, transform.localPosition.z);
        }

        //fire projectile
        if ((Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) && Time.time - lastShot >= 0.1f)
        {
            lastShot = Time.time;
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.localRotation, canvas.transform);
        }
    }
}
