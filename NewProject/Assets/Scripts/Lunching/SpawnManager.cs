using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //���ӸŴ����� �ִ� ���ӿ������� -> ������ 20223413
    public GameManager gameManager;
    public UIManager UIManager;

    //���� ó�����۽� �ʿ��� �÷��̾� ���� -> ������ 20223413
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject[] itemPrefabs;
    //�Ŀ��� ǥ�� ������Ʈ ���� -> ������ 20223413
    public GameObject powerIndicate;
    public GameObject invincibeIndicator;

    //�Ŀ��� ���� ���� ���ϱ� -> 20223413 ������
    public int powerCount = 1;
    public int waveNumber = 1;

    public int enemyCount = 0;

    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        // ��ũ��Ʈ �ޱ� -> ������ 20223413
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetGameOver())
        {
            return;
        }

        //���ӿ����� �ƴϸ� �����Ŵ��� Ȱ�� -> ������ 20223413
        //�÷��̾��±װ� �ִ� ������Ʈ�� �ִ��� Ȯ���ϱ� -> ������ 20223413
        GameObject playerInstant = GameObject.FindGameObjectWithTag("Player");
        enemyCount = FindObjectsOfType<Enemy>().Length;

        //���� �÷��̾��±װ� �ִ� ������Ʈ�� ���ٸ� ������ ó�� Ȥ�� �ٽ� ���۵Ȱ��̹Ƿ� ���̺�ܰ�, �Ŀ�����������, �÷��̾���� �� ���ʹ�, �Ŀ���ǥ�ø� �ʱ�ȭ�Ѵ� -> 20223413
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

        //�÷��̾��±װ� �ִ� ������Ʈ�� �����Ѵٸ� ������ ���۵ȰŴ� -> ������ 20223413
        if (enemyCount == 0)
        {
            waveNumber++;
            UIManager.Leveling(waveNumber);
            SpawnEnemy(waveNumber);
            //���̺극���� 3�� ����϶����� �Ŀ��� ���� ������ 1�ø� -> ������ 20223413
            if (waveNumber % 3 == 0)
            {
                powerCount++;
                SpawnItem(powerCount);
            }
            //���̺극���� 3�� ����� �ƴϸ� �״�� �����Ѵ� -> ������ 20223413
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

    // ���� ����ŭ ������Ʈ�� ������ - ������ 20223413 
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
