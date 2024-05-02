using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_20193020 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;

    public GameObject mainMenu;
    public GameObject title;

    public GameManager_20193020 gameManager;

    void Start()
    {
        defaultScale = buttonScale.localScale;

        gameManager = GameObject.Find("GameManager_20193020").GetComponent<GameManager_20193020>();
    }

    public void OnBtnClick()
    {
        switch (currentType)
        {
            case BTNType.StartGame:
                Debug.Log("게임 시작!");
                break;
        }

        gameManager.gameOver = false;
        Debug.Log(gameManager.gameOver);

        mainMenu.SetActive(false);
        title.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
