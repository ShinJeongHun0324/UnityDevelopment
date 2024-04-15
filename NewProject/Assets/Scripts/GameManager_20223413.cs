using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_20223413 : MonoBehaviour
{
    //싱글톤 패턴 객체로 게임에서 씬이 바뀌어도 오직 하나만 존재할 것이며 게임을 전체적으로 관장할 게임매니저 객체 - 정민주 20223413
    private static GameManager_20223413 instance = null;

    //게임 시작 시간 변수 - 정민주 20223413
    public float startGameTime = 0f;
    
    //게임시작후 흐른 시간 변수 - 정민주 20223413
    public float flowingTime = 0f; 
    
    //게임오버 변수 - 정민주 20223413
    public bool gameOver = true;

    // Start is called before the first frame update
    void Awake()
    {
        //인스턴스 객체가 비어있다면 새로생긴 해당 객체를 넣고 씬을 로드해도 파괴시키지 않는다 - 정민주 20223413
        if(instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            //이미 인스턴스 객체가 존재한다면 새로 생긴 것이므로 새로 생긴 해당 객체를 파괴한다 - 정민주 20223413
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 정민주 20223413
        if (!gameOver)
        {
            // 게임오버가 아니고 스타트시간이 0이라면 게임을 시작했다라는 의미가 된다 -> 그때 게임시작시간을 재어준다
            if (startGameTime == 0)
            {
                startGameTime = Time.time;
            }
            // 이후 게임오버가 아니고 스타트시간도 0이아니라면 - > 현재시간 - 스타트시간을 하여 게임진행 시간을 잰다
            flowingTime = Time.time - startGameTime;
            Debug.Log("time : " + flowingTime);
        }
        // 게임오버이면서 스타트시간이 0이 아니라면 게임이 이미 종료됐다는 뜻이다 - 게임시작시간과 게임 진행 시간을 초기화 한다
        else if(startGameTime != 0)
        {
            startGameTime = 0;
            flowingTime = 0;
        }
    }
}
