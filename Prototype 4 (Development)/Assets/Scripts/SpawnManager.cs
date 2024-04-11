using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // 적 프리팹
    public int enemyCount; // 현재 적의 수
    public int waveNumber = 1; // 현재 웨이브 번호
    public GameObject[] itemPrefabs; // 아이템 프리팹 배열

    private float spawnRange = 9; // 스폰 범위

    // Start is called before the first frame update
    void Start()
    {
        // 시작 시 첫 번째 웨이브 스폰
        SpawnEnemyWave(waveNumber);

        // 아이템 스폰
        SpawnItem();
    }

    // 아이템 스폰 메서드
    void SpawnItem()
    {
        // 무작위 아이템 스폰
        int randomItem = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomItem], GenerateSpawnPosition(), itemPrefabs[randomItem].transform.rotation);
    }

    // 적 스폰 메서드
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // 아이템 및 적 스폰 위치 생성 메서드
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

            // 아이템 스폰
            SpawnItem();
        }
    }
}