using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager_20223424 : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int enemyCount; 
    public int waveNumber = 1; 
    // 20223424, 20223445 파워업 변수 삭제하고, 아이템 프리팹을 배열로 다시 추가
    public GameObject[] itemPrefabs; 

    private float spawnRange = 9; // 스폰 범위

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

        // 20223424, 20223445 게임이 시작되면 아이템이 스폰되도록 하는 코드
        SpawnItem();
    }

    // 20223424, 20223445 아이템이 랜덤으로 스폰되도록 하는 메서드
    void SpawnItem()
    {
        int randomItem = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomItem], GenerateSpawnPosition(), itemPrefabs[randomItem].transform.rotation);
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 재시작
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // 현재 적의 수 체크
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // 모든 적을 물리치면 다음 웨이브 스폰
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);

            // 20223424, 20223445 다음 웨이브로 넘어가면 아이템이 하나 다시 리스폰 됨
            SpawnItem();
        }
    }  
}