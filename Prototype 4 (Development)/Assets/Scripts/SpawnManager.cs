using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // �� ������
    public int enemyCount; // ���� ���� ��
    public int waveNumber = 1; // ���� ���̺� ��ȣ
    public GameObject[] itemPrefabs; // ������ ������ �迭

    private float spawnRange = 9; // ���� ����

    // Start is called before the first frame update
    void Start()
    {
        // ���� �� ù ��° ���̺� ����
        SpawnEnemyWave(waveNumber);

        // ������ ����
        SpawnItem();
    }

    // ������ ���� �޼���
    void SpawnItem()
    {
        // ������ ������ ����
        int randomItem = Random.Range(0, itemPrefabs.Length);
        Instantiate(itemPrefabs[randomItem], GenerateSpawnPosition(), itemPrefabs[randomItem].transform.rotation);
    }

    // �� ���� �޼���
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // ������ �� �� ���� ��ġ ���� �޼���
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

            // ������ ����
            SpawnItem();
        }
    }
}