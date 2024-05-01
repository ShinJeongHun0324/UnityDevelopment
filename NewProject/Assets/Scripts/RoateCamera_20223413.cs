using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoateCamera_20223413 : MonoBehaviour
{
    public float rotationSpeed = 100;
    
    //게임오버 확인용 -> 정민주 20223413 
    public GameManager_20223413 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //스크립트 받기 -> 정민주 20223413
        gameManager = GameObject.Find("GameManger_20223413").GetComponent<GameManager_20223413>();
    }

    // Update is called once per frame
    void Update()
    {
        //게임오버가 아니면 움직인다 -> 정민주 20223413
        if(!gameManager.gameOver)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
        }
        //게임오버라면 카메라를 원상복귀 시키고 움직이지 못하도록 한다 - > 정민주 20223413
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
