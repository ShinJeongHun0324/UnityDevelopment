using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieManager_20223403 : MonoBehaviour
{
    public int lifeCount;
    public Text lifeText;

    void Awake()
    {
        lifeText.text = "Life : " + lifeCount;
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            if (lifeCount > 0)
            {
                lifeCount--;
                Debug.Log("" + lifeCount);
                lifeText.text = "Life : " + lifeCount;
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        // 임시로 만든 메서드입니다,
        // 최종적으로 합치실 때 GameOver시 발생하는 함수가 있다면
        // 이 메서드를 지우고, else문에 함수 이름 넣어주세요!
        Debug.Log("Game Over!!!");
        lifeText.text = "Life : 0";
    }
}
