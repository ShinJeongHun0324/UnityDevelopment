using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_20223441 : MonoBehaviour
{
    public GameObject gameOverUI; // ���� ���� UI
    //public GameObject mainMenuUI; // ���� �޴� UI -- ���߿� ����ֱ�. sync fork ���� ���θ޴� ������ ������ ��.
    public Button restartButton; // Restart ��ư
    //public Button mainMenuButton; // Main Menu ��ư

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        //mainMenuButton.onClick.AddListener(MainMenuLoad);
    }

    void Update()
    {
        // U Ű�� ������ �� ���� ���� UI Ȱ��ȭ -- ���߿� ����� 0�� ������ ���ӿ��� UI�� Ȱ��ȭ �ǵ��� ����
        if (Input.GetKeyDown(KeyCode.U))
        {
            ShowGameOverUI();
        }
    }

    // ���� ���� UI Ȱ��ȭ
    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

    // Restart ��ư Ŭ�� �� ȣ��� �޼���
    public void RestartGame()
    {
        // ���� ���� UI ��Ȱ��ȭ
        gameOverUI.SetActive(false);

        // ���� �ٽ� ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // ���� �޴��� ���ư��� ��ư Ŭ�� �� ȣ��� �޼���
    //public void MainMenuLoad()
    //{
        // ���� �޴� UI Ȱ��ȭ
        //mainMenuUI.SetActive(true);
    //}
}