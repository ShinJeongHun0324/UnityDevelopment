using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager_20223424 : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int enemyCount; 
    public int waveNumber = 1; 
    // 20223424, 20223445 �Ŀ��� ���� �����ϰ�, ������ �������� �迭�� �ٽ� �߰�
    public GameObject[] itemPrefabs; 

    private float spawnRange = 9; // ���� ����

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

        // 20223424, 20223445 ������ ���۵Ǹ� �������� �����ǵ��� �ϴ� �ڵ�
        SpawnItem();
    }

    // 20223424, 20223445 �������� �������� �����ǵ��� �ϴ� �޼���
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
        // ���� �����
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // ���� ���� �� üũ
        enemyCount = FindObjectsOfType<Enemy>().Length;

        // ��� ���� ����ġ�� ���� ���̺� ����
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);

            // 20223424, 20223445 ���� ���̺�� �Ѿ�� �������� �ϳ� �ٽ� ������ ��
            SpawnItem();
        }
    }  
}