using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : MonoBehaviour
{

    //player 2 inputs
    private float horizontalInputP2;
    private float verticalInputP2;
    private float lastShot = 0;
    private Rigidbody2D rigidBody;
    public GameObject prefab;
    public GameObject canvas;
    public int speed;
    private int playerHP = 3;
    public TextMeshProUGUI p2LivesText;
    private bool isInvincible = false;
    private SpriteRenderer shipFlashing;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        shipFlashing = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //get player 2 inputs
        horizontalInputP2 = Input.GetAxis("Horizontal2");
        verticalInputP2 = Input.GetAxis("Vertical2");

        //player 2 controls
        rigidBody.AddForce(Vector3.up * verticalInputP2 * Time.deltaTime * speed, ForceMode2D.Impulse);
        rigidBody.AddForce(Vector3.right * horizontalInputP2 * Time.deltaTime * speed, ForceMode2D.Impulse);

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

        if (playerHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator IFrames()
    {
        for (int i = 0; i < 5; i++)
        {
            shipFlashing.enabled = false;
            yield return new WaitForSeconds(0.1f);
            shipFlashing.enabled = true;
            yield return new WaitForSeconds(0.1f);

        }
        isInvincible = false;
        Debug.Log("iframes over");
    }

    IEnumerator DamagedFlash()
    {
        
        for (int i = 0; i < 5; i++)
        {
            shipFlashing.enabled = false;
            yield return new WaitForSeconds(0.2f);
            shipFlashing.enabled = true;

        }
        Debug.Log("flashing over");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isInvincible)
        {
            isInvincible = true;
            ChangePlayerHP(-1);
            StartCoroutine(IFrames());
            
        }

        if (collision.gameObject.CompareTag("Life Powerup"))
        {
            ChangePlayerHP(1);
        }
    }

    private void ChangePlayerHP(int plusOrMinus)
    {
        if (plusOrMinus == -1)
        {
            playerHP -= 1;
            p2LivesText.text = "P2: " + playerHP;
            Debug.Log(playerHP);
        }

        else if (plusOrMinus == 1 && playerHP != 3)
        {
            playerHP += 1;
            p2LivesText.text = "P2: " + playerHP;
            Debug.Log(playerHP);
        }
    }
}
