using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    int waveNumber;
    public GameObject smallEnemy;
    private int enemiesLeft;
    public GameObject canvas;
    private int spawnPos;
    public GameObject miniBoss;
    private int miniBossNum;
    public GameObject bigBoss;
    public GameObject lifePowerup;
    public GameObject twoXPowerup;
    public GameObject fourXPowerup;
    private int powerupToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when no enemies remain, increase wave count and spawn new wave
        enemiesLeft = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemiesLeft == 0)
        {
            waveNumber++;
            SpawnWave(waveNumber);
            SpawnMiniBosses(waveNumber);
            SpawnBigBosses(waveNumber);
            SpawnPowerUp(waveNumber);
        }
    }

    void SpawnPowerUp(int waveNumber)
    {
        if(waveNumber % 2 == 0)
        {
            powerupToSpawn = Random.Range(0, 4);

            if(powerupToSpawn <= 1)
            {
                spawnPos = Random.Range(-48, 48);

                Instantiate(lifePowerup, new Vector3(spawnPos, transform.position.y, transform.position.z), transform.localRotation, canvas.transform);
            }

            else if (powerupToSpawn == 2)
            {
                spawnPos = Random.Range(-48, 48);

                Instantiate(twoXPowerup, new Vector3(spawnPos, transform.position.y, transform.position.z), transform.localRotation, canvas.transform);
            }

            else if (powerupToSpawn == 3)
            {
                spawnPos = Random.Range(-48, 48);

                Instantiate(fourXPowerup, new Vector3(spawnPos, transform.position.y, transform.position.z), transform.localRotation, canvas.transform);
            }
        }
    }

    //spawn the number of enemies of the wave number at a random range
    void SpawnWave(int enemyCount)
    {
        if(enemyCount > 6)
        {
            enemyCount = 6;
        }

        for (int i = 0; i < enemyCount; i++)
        {
            spawnPos = Random.Range(-48, 48);
            
            Instantiate(smallEnemy, new Vector3(spawnPos, transform.position.y, transform.position.z), transform.localRotation, canvas.transform);
        }
    }

    void SpawnMiniBosses(int waveNum)
    {
        if(waveNum > 12)
        {
            waveNum = 12;
        }

        for (int i = waveNum; i > 3; i-=3)
        {
            spawnPos = Random.Range(-48, 48);

            Instantiate(miniBoss, new Vector3(spawnPos, transform.position.y, transform.position.z), transform.localRotation, canvas.transform);
        }
    }

    void SpawnBigBosses(int waveNum)
    {


        if (waveNum % 5 == 0) { 

        if(waveNum > 20)
            {
                waveNum = 20;
            }

            {
                for (int i = waveNum; i > 5; i -= 5)
                {
                    spawnPos = Random.Range(-48, 48);

                    Instantiate(bigBoss, new Vector3(spawnPos, transform.position.y, transform.position.z), transform.localRotation, canvas.transform);
                }
            }
        }
    }
}
