using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieManager : MonoBehaviour
{
    public Text lifeText;

    private void Start()
    {
        lifeText.text = "Life : " + GameManager.instance.lifeCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.DecreaseLifeCount();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
