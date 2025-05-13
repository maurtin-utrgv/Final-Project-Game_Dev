using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button retryButton;
    public Button quitButton;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += ShowGameOverScreen;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= ShowGameOverScreen;
    }

    void Start()
    {
        Debug.Log("GameController started");
        if (gameOverPanel == null)
        {
            Debug.LogError("Game Over Panel is not assigned!");
        }
        gameOverPanel.SetActive(false);
        retryButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitToTitle);
    }


    void ShowGameOverScreen()
    {
        Debug.Log("Game Over triggered");
        gameOverPanel.SetActive(true);

        // Pause the game
        Time.timeScale = 0;

        // Optional: Force enable buttons if Unity isn't doing it automatically
        retryButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    void RestartGame()
    {
        // Unpause the game before restarting the scene
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void QuitToTitle()
    {
        // Unpause the game before quitting to the title screen
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }
}
