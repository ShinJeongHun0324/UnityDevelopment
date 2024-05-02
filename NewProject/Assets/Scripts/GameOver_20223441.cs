using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameOver_20223441 : MonoBehaviour
{
    public GameObject gameOverUI; // 게임 오버 UI
    public GameObject mainMenuUI; // 메인 메뉴 UI
    public Button restartButton; // Restart 버튼
    public Button mainMenuButton; // Main Menu 버튼

    // 레벨, 시간, 목숨 UI 지우기
    public GameObject TextLevelUI;
    public GameObject TextTimeUI;
    public GameObject TimePanelUI;

    // 생존 시간 출력
    public UnityEngine.UI.Text survivalTimeText; // 게임 오버 UI에 출력할 생존 시간을 표시할 Text
    private GameManager_20223413 gameManager; // 게임 매니저 참조

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(MainMenuLoad);
        gameManager = FindObjectOfType<GameManager_20223413>(); // 게임 매니저 찾기
    }

    void Update()
    {
        // U 키를 눌렀을 때 게임 오버 UI 활성화 -- 나중에 목숨이 0이 됐을때 게임오버 UI가 활성화 되도록 구현
        if (Input.GetKeyDown(KeyCode.U))
        {
            ShowGameOverUI();
        }

    }

    // 게임 오버 UI 활성화
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        RotateCamera rotateCamera = FindObjectOfType<RotateCamera>();
        if (rotateCamera != null)
        {
            rotateCamera.SetGameOver();
        }

        // 레벨, 시간, 목숨 UI 비활성화
        TextLevelUI.SetActive(false); 
        TextTimeUI.SetActive(false);
        TimePanelUI.SetActive(false);

        // 생존시간 출력
        float survivalTime = gameManager.flowingTime;
        survivalTimeText.text = "Survival Time: " + survivalTime.ToString("F1") + "s";
    }

    // Restart 버튼 클릭 시 호출될 메서드
    public void RestartGame()
    {
        // 게임 오버 UI 비활성화
        gameOverUI.SetActive(false);

        // 게임 다시 시작
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // 메인 메뉴로 돌아가는 버튼 클릭 시 호출될 메서드
    public void MainMenuLoad()
    {
        // 게임 오버 UI 비활성화
        gameOverUI.SetActive(false);

        // 메인 메뉴 UI 활성화
        mainMenuUI.SetActive(true);
    }
}