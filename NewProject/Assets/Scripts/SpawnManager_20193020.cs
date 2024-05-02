using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager_20193020 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;

    public GameObject playerPrefab;
    public GameObject indicator;

    private float spawnRange = 9;

    public GameManager_20193020 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager_20193020").GetComponent<GameManager_20193020>();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(),
                enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver == false)
        {
            enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            GameObject gamePlayer = GameObject.FindGameObjectWithTag("Player");
            if(gamePlayer == null)
            {
                Instantiate(indicator, indicator.transform.position, indicator.transform.rotation);
                Instantiate(playerPrefab, playerPrefab.transform.position, playerPrefab.transform.rotation);
                
                SpawnEnemyWave(waveNumber);

                Instantiate(powerupPrefab, GenerateSpawnPosition(),
                    powerupPrefab.transform.rotation);
            }
            else
            {
                if (enemyCount == 0)
                {
                    waveNumber++;
                    SpawnEnemyWave(waveNumber);

                    Instantiate(powerupPrefab, GenerateSpawnPosition(),
                        powerupPrefab.transform.rotation);
                }
            }

        }
    }
}