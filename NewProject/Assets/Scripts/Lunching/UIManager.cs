using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager; // ���� �Ŵ��� ����
    public SpawnManager spawnManager;

    public GameObject UIBackground;

    public GameObject gameOverUI; // ���� ���� UI
    public GameObject restartUI;
    public GameObject loadMainMenuUI;
    public GameObject survivalTimeLevelUI;

    public GameObject mainMenuUI; // ���� �޴� UI
    public GameObject startGameUI;

    public Button restartButton; // Restart ��ư
    public Button mainMenuButton; // Main Menu ��ư
    public Button startButton;

    // ����, �ð�, ��� UI 
    public GameObject timePanelUI;
    public GameObject levlePanelUI;
    public GameObject lifePanelUI;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI lifeText;
    // ���� �ð� ���
    public TextMeshProUGUI survivalTimeText; // ���� ���� UI�� ����� ���� �ð��� ǥ���� Text

    void Start()
    {
        UIBackground.SetActive(true);

        gameOverUI.SetActive(false);
        restartUI.SetActive(false);
        loadMainMenuUI.SetActive(false); 
        survivalTimeLevelUI.SetActive(false);

        mainMenuUI.SetActive(true);
        startGameUI.SetActive(true);

        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(MainMenuLoad);
        startButton.onClick.AddListener(startGame);

        timePanelUI.SetActive(false);
        levlePanelUI.SetActive(false);
        lifePanelUI.SetActive(false);

        gameManager = FindObjectOfType<GameManager>(); // ���� �Ŵ��� ã��
    }

    public void startGame()
    {
        mainMenuUI.SetActive(false);
        startGameUI.SetActive(false);

        UIBackground.SetActive(false);

        timePanelUI.SetActive(true);
        levlePanelUI.SetActive(true);
        lifePanelUI.SetActive(true);

        gameManager.ResetTime();
        gameManager.TrunGameOver();
    }

    // ���� ���� UI Ȱ��ȭ
    public void ShowGameOverUI()
    {
        UIBackground.SetActive(true);

        gameOverUI.SetActive(true);
        restartUI.SetActive(true);
        loadMainMenuUI.SetActive(true);
        survivalTimeLevelUI.SetActive(true);

        // ����, �ð�, ��� UI ��Ȱ��ȭ
        timePanelUI.SetActive(false);
        levlePanelUI.SetActive(false);
        lifePanelUI.SetActive(false);

        // �����ð� ���
        float survivalTime = gameManager.GetFlowingTime();
        survivalTimeText.text = "Play Time: " + survivalTime.ToString("F1") + "s / Level : " + spawnManager.GetWaveN();
    }

    // Restart ��ư Ŭ�� �� ȣ��� �޼���
    public void RestartGame()
    {
        // ���� ���� UI ��Ȱ��ȭ
        UIBackground.SetActive(false);

        timePanelUI.SetActive(true);
        levlePanelUI.SetActive(true);
        lifePanelUI.SetActive(true);

        // ���� �ٽ� ����
        gameManager.ResetTime();
        gameManager.TrunGameOver();
    }

    // ���� �޴��� ���ư��� ��ư Ŭ�� �� ȣ��� �޼���
    public void MainMenuLoad()
    {
        // ���� ���� UI ��Ȱ��ȭ
        gameOverUI.SetActive(false);
        restartUI.SetActive(false);
        loadMainMenuUI.SetActive(false);
        survivalTimeLevelUI.SetActive(false);

        mainMenuUI.SetActive(true);
        startGameUI.SetActive(true);
    }

    public void Timer(float time)
    {
        timeText.text = "Time : " + time.ToString("F1") + "s";
    }

    public void Leveling(int level)
    {
        levelText.text = "Level : " + level;
    }

    public void Lifeing(int life)
    {
        lifeText.text = "Life : " + life;
    }
}