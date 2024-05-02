using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameOver_20223441 : MonoBehaviour
{
    public GameObject gameOverUI; // ���� ���� UI
    public GameObject mainMenuUI; // ���� �޴� UI
    public Button restartButton; // Restart ��ư
    public Button mainMenuButton; // Main Menu ��ư

    // ����, �ð�, ��� UI �����
    public GameObject TextLevelUI;
    public GameObject TextTimeUI;
    public GameObject TimePanelUI;

    // ���� �ð� ���
    public UnityEngine.UI.Text survivalTimeText; // ���� ���� UI�� ����� ���� �ð��� ǥ���� Text
    private GameManager_20223413 gameManager; // ���� �Ŵ��� ����

    void Start()
    {
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(MainMenuLoad);
        gameManager = FindObjectOfType<GameManager_20223413>(); // ���� �Ŵ��� ã��
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
        RotateCamera rotateCamera = FindObjectOfType<RotateCamera>();
        if (rotateCamera != null)
        {
            rotateCamera.SetGameOver();
        }

        // ����, �ð�, ��� UI ��Ȱ��ȭ
        TextLevelUI.SetActive(false); 
        TextTimeUI.SetActive(false);
        TimePanelUI.SetActive(false);

        // �����ð� ���
        float survivalTime = gameManager.flowingTime;
        survivalTimeText.text = "Survival Time: " + survivalTime.ToString("F1") + "s";
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
    public void MainMenuLoad()
    {
        // ���� ���� UI ��Ȱ��ȭ
        gameOverUI.SetActive(false);

        // ���� �޴� UI Ȱ��ȭ
        mainMenuUI.SetActive(true);
    }
}