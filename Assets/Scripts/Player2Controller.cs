using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    //player 2 inputs
    private float horizontalInputP2;
    private float verticalInputP2;
    private Rigidbody2D rigidBody;

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

        rigidBody.AddForce(Vector3.up * verticalInputP2 * Time.deltaTime * 70000);
        rigidBody.AddForce(Vector3.right * horizontalInputP2 * Time.deltaTime * 70000);
    }
}
