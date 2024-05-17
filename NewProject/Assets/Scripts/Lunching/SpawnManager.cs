using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //게임매니저에 있는 게임오버판정 -> 정민주 20223413
    public GameManager gameManager;
    public UIManager UIManager;

    //게임 처음시작시 필요한 플레이어 스폰 -> 정민주 20223413
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject[] itemPrefabs;
    //파워업 표시 오브젝트 스폰 -> 정민주 20223413
    public GameObject powerIndicate;
    public GameObject invincibeIndicator;

    //파워업 생성 갯수 정하기 -> 20223413 정민주
    public int powerCount = 1;
    public int waveNumber = 1;

    public int enemyCount = 0;

    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        // 스크립트 받기 -> 정민주 20223413
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetGameOver())
        {
            return;
        }

        //게임오버가 아니면 스폰매니저 활성 -> 정민주 20223413
        //플레이어태그가 있는 오브젝트가 있는지 확인하기 -> 정민주 20223413
        GameObject playerInstant = GameObject.FindGameObjectWithTag("Player");
        enemyCount = FindObjectsOfType<Enemy>().Length;

        //만약 플레이어태그가 있는 오브젝트가 없다면 게임이 처음 혹은 다시 시작된것이므로 웨이브단계, 파워업생성갯수, 플레이어생성 및 에너미, 파워업표시를 초기화한다 -> 20223413
        if (playerInstant == null)
        {
            waveNumber = 1;
            powerCount = 1;
            Instantiate(powerIndicate, powerIndicate.transform.position,
                powerIndicate.transform.rotation);
            Instantiate(invincibeIndicator, invincibeIndicator.transform.position
                , invincibeIndicator.transform.rotation);
            Instantiate(playerPrefab, playerPrefab.transform.position,
                playerPrefab.transform.rotation);
            SpawnEnemy(waveNumber);
            SpawnItem(powerCount);
            UIManager.Leveling(waveNumber);
            return;
        }

        //플레이어태그가 있는 오브젝트가 존재한다면 게임이 시작된거다 -> 정민주 20223413
        if (enemyCount == 0)
        {
            waveNumber++;
            UIManager.Leveling(waveNumber);
            SpawnEnemy(waveNumber);
            //웨이브레벨이 3의 배수일때마다 파워업 생성 갯수를 1늘림 -> 정민주 20223413
            if (waveNumber % 3 == 0)
            {
                powerCount++;
                SpawnItem(powerCount);
            }
            //웨이브레벨이 3의 배수가 아니면 그대로 생성한다 -> 정민주 20223413
            else
            {
                SpawnItem(powerCount);
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    // 들어온 수만큼 오브젝트를 생성함 - 정민주 20223413 
    void SpawnEnemy(int toSpawnCount)
    {
        for (int i = 0; i < toSpawnCount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(),
                enemyPrefab.transform.rotation);
        }
    }

    void SpawnItem(int toSpawnCount)
    {
        for (int i = 0; i < toSpawnCount; i++)
        {
            int randomItem = Random.Range(0, itemPrefabs.Length);
            Instantiate(itemPrefabs[randomItem], GenerateSpawnPosition(), itemPrefabs[randomItem].transform.rotation);
        }
    }

    public int GetWaveN()
    {
        return waveNumber;
    }

    public void ResetWave()
    {
        waveNumber = 1;
    }
}
