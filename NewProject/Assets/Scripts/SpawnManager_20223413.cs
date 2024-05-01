using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager_20223413 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount = 0;
    public int waveNumber = 1;
    public GameObject powerupPrefab;
    //파워업 생성 갯수 정하기 -> 20223413 정민주
    public int powerCount = 1;

    private float spawnRange = 9;

    //레벨텍스트 찍기위한 텍스트 객체 - 20223413 정민주
    public TextMeshProUGUI levelText;
    //게임 처음시작시 필요한 플레이어 스폰 -> 정민주 20223413
    public GameObject playerPrefab;
    //파워업 표시 오브젝트 스폰 -> 정민주 20223413
    public GameObject powerIndicate;
    //게임매니저에 있는 게임오버판정 -> 정민주 20223413
    public GameManager_20223413 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // 스크립트 받기 -> 정민주 20223413
        gameManager = GameObject.Find("GameManger_20223413").GetComponent<GameManager_20223413>();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    // 들어온 수만큼 오브젝트를 생성함 - 정민주 20223413 
    void SpawnObject(int toSpawnCount, GameObject objPrefab)
    {
        for (int i = 0; i < toSpawnCount; i++)
        {
            Instantiate(objPrefab, GenerateSpawnPosition(),
                objPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //게임오버가 아니면 스폰매니저 활성 -> 정민주 20223413
        if(!gameManager.gameOver)
        {
            //플레이어태그가 있는 오브젝트가 있는지 확인하기 -> 정민주 20223413
            GameObject playerInstant = GameObject.FindGameObjectWithTag("Player");
            enemyCount = FindObjectsOfType<Enemy_20223413>().Length;
            //만약 플레이어태그가 있는 오브젝트가 없다면 게임이 처음시작된것이므로 웨이브단계, 파워업생성갯수, 플레이어생성 및 에너미, 파워업표시를 초기화한다 -> 20223413
            if (playerInstant == null)
            {
                waveNumber = 1;
                powerCount = 1;
                Instantiate(powerIndicate, powerIndicate.transform.position,
                    powerIndicate.transform.rotation);
                Instantiate(playerPrefab, playerPrefab.transform.position,
                    playerPrefab.transform.rotation);
                SpawnObject(waveNumber, enemyPrefab);
                SpawnObject(powerCount, powerupPrefab);
                levelText.text = "Level : " + waveNumber;
            }
            //플레이어태그가 있는 오브젝트가 존재한다면 게임이 시작된거다 -> 정민주 20223413
            if (playerInstant != null)
            {
                if (enemyCount == 0)
                {
                    waveNumber++;
                    levelText.text = "Level : " + waveNumber;
                    SpawnObject(waveNumber, enemyPrefab);
                    //웨이브레벨이 3의 배수일때마다 파워업 생성 갯수를 1늘림 -> 정민주 20223413
                    if (waveNumber % 3 == 0)
                    {
                        powerCount++;
                        SpawnObject(powerCount, powerupPrefab);
                    }
                    //웨이브레벨이 3의 배수가 아니면 그대로 생성한다 -> 정민주 20223413
                    else
                    {
                        SpawnObject(powerCount, powerupPrefab);
                    }
                }
            }
        }
    }

}
