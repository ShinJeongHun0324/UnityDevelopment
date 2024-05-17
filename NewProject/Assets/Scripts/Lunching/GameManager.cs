using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //�̱��� ���� ��ü�� ���ӿ��� ���� �ٲ� ���� �ϳ��� ������ ���̸� ������ ��ü������ ������ ���ӸŴ��� ��ü - ������ 20223413
    private static GameManager instance = null;
    public UIManager UIManager;

    //���ӿ��� ���� - ������ 20223413
    private bool gameOver = true;
    //���� ���� �ð� ���� - ������ 20223413
    public float startGameTime = 0f;
    //���ӽ����� �帥 �ð� ���� - ������ 20223413
    public float flowingTime = 0f; 
    public int lifeCount = 3;

    // Start is called before the first frame update
    void Awake()
    {
        //�ν��Ͻ� ��ü�� ����ִٸ� ���λ��� �ش� ��ü�� �ְ� ���� �ε��ص� �ı���Ű�� �ʴ´� - ������ 20223413
        if(instance == null) 
        {
            instance = this;
            ResetLifeCount();
            ResetTime();
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            //�̹� �ν��Ͻ� ��ü�� �����Ѵٸ� ���� ���� ���̹Ƿ� ���� ���� �ش� ��ü�� �ı��Ѵ� - ������ 20223413
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ������ 20223413
        if (!gameOver)
        {
            // ���ӿ����� �ƴϰ� ��ŸƮ�ð��� 0�̶�� ������ �����ߴٶ�� �ǹ̰� �ȴ� -> �׶� ���ӽ��۽ð��� ����ش�
            if (startGameTime == 0)
            {
                startGameTime = Time.time;
            }
            // ���� ���ӿ����� �ƴϰ� ��ŸƮ�ð��� 0�̾ƴ϶�� - > ����ð� - ��ŸƮ�ð��� �Ͽ� �������� �ð��� ���
            flowingTime = Time.time - startGameTime;
            UIManager.Timer(flowingTime);
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
    public void TrunGameOver()
    {
        gameOver = !gameOver;
    }

    //���ӿ����� �ߵ��ϴ� �Լ� ���� �ִ� ���� ������ ��� ������Ʈ�� �����Ѵ� -> ������ 20223413
    void DestoryAll()
    {
        GameObject indicatorPower = GameObject.FindWithTag("Indicator");
        GameObject indicatorInvincible = GameObject.FindWithTag("Invincibe");
        GameObject player = GameObject.FindWithTag("Player");
        GameObject[] powerUPs = GameObject.FindGameObjectsWithTag("Powerup");
        GameObject[] invincibles = GameObject.FindGameObjectsWithTag("isInvincible");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }
        foreach (GameObject powerUP in powerUPs)
        {
            Destroy(powerUP);
        }
        foreach (GameObject invincible in invincibles)
        {
            Destroy(invincible);
        }
        Destroy(player);
        Destroy(indicatorPower);
        Destroy(indicatorInvincible);
    }

    public float GetFlowingTime()
    {
        return flowingTime;
    }

    public void ResetTime()
    {
        startGameTime = 0;
        flowingTime = 0;
    }

    public int GetLife()
    {
        return lifeCount;
    }
    public void DecreaseLifeCount()
    {
        DestoryAll();
        if (lifeCount <= 0)
        {
            TrunGameOver();
            ResetLifeCount();
            UIManager.ShowGameOverUI();
            return;
        }
        lifeCount--;
    }
    public void ResetLifeCount()
    {
        lifeCount = 3;
    }
}
