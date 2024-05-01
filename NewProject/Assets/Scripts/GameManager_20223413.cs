using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager_20223413 : MonoBehaviour
{
    //�̱��� ���� ��ü�� ���ӿ��� ���� �ٲ� ���� �ϳ��� ������ ���̸� ������ ��ü������ ������ ���ӸŴ��� ��ü - ������ 20223413
    private static GameManager_20223413 instance = null;

    //���� ���� �ð� ���� - ������ 20223413
    public float startGameTime = 0f;
    
    //���ӽ����� �帥 �ð� ���� - ������ 20223413
    public float flowingTime = 0f; 
    
    //���ӿ��� ���� - ������ 20223413
    public bool gameOver = true;

    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Awake()
    {
        //�ν��Ͻ� ��ü�� ����ִٸ� ���λ��� �ش� ��ü�� �ְ� ���� �ε��ص� �ı���Ű�� �ʴ´� - ������ 20223413
        if(instance == null) 
        {
            instance = this;
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
        if(Input.GetKeyUp(KeyCode.Y))
        {
            gameOver = false;
        }

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
            timeText.text = "Time : " + flowingTime.ToString("F1") + "s";
        }
        // ���ӿ����̸鼭 ��ŸƮ�ð��� 0�� �ƴ϶�� ������ �̹� ����ƴٴ� ���̴� - > ���ӽ��۽ð��� ���� ���� �ð�, ��� ������Ʈ�� �ʱ�ȭ �Ѵ�
        else if(startGameTime != 0)
        {
            startGameTime = 0;
            flowingTime = 0;
            DestoryAll();
        }
    }

    //���ӿ����� �ߵ��ϴ� �Լ� ���� �ִ� ���� ������ ��� ������Ʈ�� �����Ѵ� -> ������ 20223413
    void DestoryAll()
    {
        GameObject indicatorPower = GameObject.FindWithTag("Indicator");
        GameObject player = GameObject.FindWithTag("Player");
        GameObject[] powerUPs = GameObject.FindGameObjectsWithTag("Powerup");
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        //GameObject[] invincibles = GameObject.FindGameObjectsWithTag("isInvincible");
        foreach (GameObject enemy in enemys)
        {
            Destroy(enemy);
        }
        foreach (GameObject powerUP in powerUPs)
        {
            Destroy(powerUP);
        }
        Destroy(player);
        Destroy(indicatorPower);
    }
}
