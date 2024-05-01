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
    //�Ŀ��� ���� ���� ���ϱ� -> 20223413 ������
    public int powerCount = 1;

    private float spawnRange = 9;

    //�����ؽ�Ʈ ������� �ؽ�Ʈ ��ü - 20223413 ������
    public TextMeshProUGUI levelText;
    //���� ó�����۽� �ʿ��� �÷��̾� ���� -> ������ 20223413
    public GameObject playerPrefab;
    //�Ŀ��� ǥ�� ������Ʈ ���� -> ������ 20223413
    public GameObject powerIndicate;
    //���ӸŴ����� �ִ� ���ӿ������� -> ������ 20223413
    public GameManager_20223413 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // ��ũ��Ʈ �ޱ� -> ������ 20223413
        gameManager = GameObject.Find("GameManger_20223413").GetComponent<GameManager_20223413>();
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }

    // ���� ����ŭ ������Ʈ�� ������ - ������ 20223413 
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
        //���ӿ����� �ƴϸ� �����Ŵ��� Ȱ�� -> ������ 20223413
        if(!gameManager.gameOver)
        {
            //�÷��̾��±װ� �ִ� ������Ʈ�� �ִ��� Ȯ���ϱ� -> ������ 20223413
            GameObject playerInstant = GameObject.FindGameObjectWithTag("Player");
            enemyCount = FindObjectsOfType<Enemy_20223413>().Length;
            //���� �÷��̾��±װ� �ִ� ������Ʈ�� ���ٸ� ������ ó�����۵Ȱ��̹Ƿ� ���̺�ܰ�, �Ŀ�����������, �÷��̾���� �� ���ʹ�, �Ŀ���ǥ�ø� �ʱ�ȭ�Ѵ� -> 20223413
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
            //�÷��̾��±װ� �ִ� ������Ʈ�� �����Ѵٸ� ������ ���۵ȰŴ� -> ������ 20223413
            if (playerInstant != null)
            {
                if (enemyCount == 0)
                {
                    waveNumber++;
                    levelText.text = "Level : " + waveNumber;
                    SpawnObject(waveNumber, enemyPrefab);
                    //���̺극���� 3�� ����϶����� �Ŀ��� ���� ������ 1�ø� -> ������ 20223413
                    if (waveNumber % 3 == 0)
                    {
                        powerCount++;
                        SpawnObject(powerCount, powerupPrefab);
                    }
                    //���̺극���� 3�� ����� �ƴϸ� �״�� �����Ѵ� -> ������ 20223413
                    else
                    {
                        SpawnObject(powerCount, powerupPrefab);
                    }
                }
            }
        }
    }

}
