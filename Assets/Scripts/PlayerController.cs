using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //player 1 inputs
    private float horizontalInputP1;
    private float verticalInputP1;
    private float lastShot = 0;
    private Rigidbody2D rigidBody;
    public GameObject projectile;
    public GameObject canvas;
    public int speed;
    private int playerHP = 30;
    public TextMeshProUGUI p1LivesText;
    private bool isInvincible = false;
    private SpriteRenderer shipFlashing;
    public GameObject engines;
    private Image bodyFlashing;
    public GameObject twoX;
    public GameObject fourX;
    private bool hasTwoX = false;
    private bool hasFourX = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        shipFlashing = engines.gameObject.GetComponent<SpriteRenderer>();
        bodyFlashing = gameObject.GetComponent<Image>();
        Debug.Log(playerHP);
    }

    // Update is called once per frame
    void Update()
    {
        //get player 1 inputs
        horizontalInputP1 = Input.GetAxis("Horizontal");
        verticalInputP1 = Input.GetAxis("Vertical");

        //player 1 controls
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
            if (hasTwoX)
            {
                lastShot = Time.time;
                Instantiate(twoX, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.localRotation, canvas.transform);
            }

            else if (hasFourX)
            {
                lastShot = Time.time;
                Instantiate(fourX, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.localRotation, canvas.transform);
            }

            else
            {
                lastShot = Time.time;
                Instantiate(projectile, new Vector3(transform.position.x, transform.position.y + 10, transform.position.z), transform.localRotation, canvas.transform);
            }
        }

        if(playerHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator IFrames()
    {
        for (int i = 0; i < 5; i++)
        {
            shipFlashing.enabled = false;
            bodyFlashing.enabled = false;
            yield return new WaitForSeconds(0.1f);
            shipFlashing.enabled = true;
            bodyFlashing.enabled = true;
            yield return new WaitForSeconds(0.1f);

        }
        isInvincible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy Projectile")) && !isInvincible)
        {
            hasTwoX = false;
            hasFourX = false;
            isInvincible = true;
            ChangePlayerHP(-1);
            StartCoroutine(IFrames());
        }

        if(collision.gameObject.CompareTag("Life Powerup"))
        {
            ChangePlayerHP(1);
        }

        if (collision.gameObject.CompareTag("2x"))
        {
            hasTwoX = true;
        }

        if (collision.gameObject.CompareTag("4x"))
        {
            hasFourX = true;
        }
    }

    private void ChangePlayerHP(int plusOrMinus)
    {
        if(plusOrMinus == -1)
        {
            playerHP -= 1;
            p1LivesText.text = "P1: " + playerHP;
        }

        else if(plusOrMinus == 1 && playerHP != 3)
        {
            playerHP += 1;
            p1LivesText.text = "P1: " + playerHP;
        }
    }
}
