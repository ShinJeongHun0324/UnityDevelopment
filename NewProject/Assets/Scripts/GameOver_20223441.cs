using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_20223441 : MonoBehaviour
{
    public GameObject gameOverUI; // 게임 오버 UI
    //public GameObject mainMenuUI; // 메인 메뉴 UI -- 나중에 집어넣기. sync fork 이후 메인메뉴 프리팹 넣으면 됨.
    public Button restartButton; // Restart 버튼
    //public Button mainMenuButton; // Main Menu 버튼

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        //mainMenuButton.onClick.AddListener(MainMenuLoad);
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
    //public void MainMenuLoad()
    //{
        // 메인 메뉴 UI 활성화
        //mainMenuUI.SetActive(true);
    //}
}