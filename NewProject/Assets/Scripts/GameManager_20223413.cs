using System.Collections;
using System.Collections.Generic;
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
            Debug.Log("time : " + flowingTime);
        }
        // ���ӿ����̸鼭 ��ŸƮ�ð��� 0�� �ƴ϶�� ������ �̹� ����ƴٴ� ���̴� - ���ӽ��۽ð��� ���� ���� �ð��� �ʱ�ȭ �Ѵ�
        else if(startGameTime != 0)
        {
            startGameTime = 0;
            flowingTime = 0;
        }
    }
}
