using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject mainGame;
    public GameObject titleScreen;
 
    private bool gameStarted = false;
    public GameObject player2;
    public GameObject p2ScoreText;
    private bool isGameOver = false;
    public AudioSource titleMusic;
    public AudioSource gameMusic;
   

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //exit
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }

        //1 player start
        if (Input.GetKeyDown(KeyCode.Alpha1) && gameStarted == false)
        {
            gameStarted = true;
            titleScreen.SetActive(false);
            mainGame.SetActive(true);
            titleMusic.Stop();
            gameMusic.Play();
        }

        //2 players start
        if (Input.GetKeyDown(KeyCode.Alpha2) && gameStarted == false)
        {
            gameStarted = true;
            titleScreen.SetActive(false);
            mainGame.SetActive(true);
            player2.SetActive(true);
            p2ScoreText.SetActive(true);
            titleMusic.Stop();
            gameMusic.Play();
        }

        //restart game if game is over
        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && isGameOver == true)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void GameOver()
    {
        isGameOver = true;
        gameMusic.Stop();
    }

}
