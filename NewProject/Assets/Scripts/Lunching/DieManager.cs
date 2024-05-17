using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieManager : MonoBehaviour
{
    public GameManager gameManager;
    public UIManager UIManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UIManager.Lifeing(gameManager.GetLife());
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Death");
        if (other.CompareTag("Player"))
        {
            Debug.Log("kill");
            gameManager.DecreaseLifeCount();
            UIManager.Lifeing(gameManager.GetLife());
        }
    }
}
