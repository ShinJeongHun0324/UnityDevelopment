using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager_20223413 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    public int powerCount = 1;

    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        // ���̺� ���� �α� ��� - ������ 20223413
        Debug.Log("Level : " + waveNumber);
        SpawnEnemyWave(waveNumber);

        SpawnPowerup(powerCount);
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

    // ���� ����ŭ �Ŀ��� ������ - ������ 20223413 
    void SpawnPowerup(int powerupToSpanw)
    {
        for (int i = 0; i < powerupToSpanw; i++)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(),
                powerupPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (enemyCount == 0)
        {
            waveNumber++;
            Debug.Log("Level : " + waveNumber);
            SpawnEnemyWave(waveNumber);
            //���̺극���� 3�� ����϶����� �Ŀ��� ���� ������ 1�ø� - ������ 20223413
            if(waveNumber % 3 == 0)
            {
                powerCount++;
                SpawnPowerup(powerCount);
            }
            else
            {
                SpawnPowerup(powerCount);
            }
        }
    }
}
