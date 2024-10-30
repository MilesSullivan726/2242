using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //player 1 inputs
    private float horizontalInputP1;
    private float verticalInputP1;

    private Rigidbody2D rigidBody;

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


        rigidBody.AddForce(Vector3.up * verticalInputP1 * Time.deltaTime * 70000);
        rigidBody.AddForce(Vector3.right * horizontalInputP1 * Time.deltaTime * 70000);

        

    }
}
