using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager; // 게임 매니저 참조
    public SpawnManager spawnManager;

    public GameObject UIBackground;

    public GameObject gameOverUI; // 게임 오버 UI
    public GameObject restartUI;
    public GameObject loadMainMenuUI;
    public GameObject survivalTimeLevelUI;

    public GameObject mainMenuUI; // 메인 메뉴 UI
    public GameObject startGameUI;

    public Button restartButton; // Restart 버튼
    public Button mainMenuButton; // Main Menu 버튼
    public Button startButton;

    // 레벨, 시간, 목숨 UI 
    public GameObject timePanelUI;
    public GameObject levlePanelUI;
    public GameObject lifePanelUI;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI lifeText;
    // 생존 시간 출력
    public TextMeshProUGUI survivalTimeText; // 게임 오버 UI에 출력할 생존 시간을 표시할 Text

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

        gameManager = FindObjectOfType<GameManager>(); // 게임 매니저 찾기
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

    // 게임 오버 UI 활성화
    public void ShowGameOverUI()
    {
        UIBackground.SetActive(true);

        gameOverUI.SetActive(true);
        restartUI.SetActive(true);
        loadMainMenuUI.SetActive(true);
        survivalTimeLevelUI.SetActive(true);

        // 레벨, 시간, 목숨 UI 비활성화
        timePanelUI.SetActive(false);
        levlePanelUI.SetActive(false);
        lifePanelUI.SetActive(false);

        // 생존시간 출력
        float survivalTime = gameManager.GetFlowingTime();
        survivalTimeText.text = "Play Time: " + survivalTime.ToString("F1") + "s / Level : " + spawnManager.GetWaveN();
    }

    // Restart 버튼 클릭 시 호출될 메서드
    public void RestartGame()
    {
        // 게임 오버 UI 비활성화
        UIBackground.SetActive(false);

        timePanelUI.SetActive(true);
        levlePanelUI.SetActive(true);
        lifePanelUI.SetActive(true);

        // 게임 다시 시작
        gameManager.ResetTime();
        gameManager.TrunGameOver();
    }

    // 메인 메뉴로 돌아가는 버튼 클릭 시 호출될 메서드
    public void MainMenuLoad()
    {
        // 게임 오버 UI 비활성화
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