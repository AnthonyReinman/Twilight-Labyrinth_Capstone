using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverScreen; //Game Over UI
    public bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        InitializeGameOverScreen();
    }

    private void InitializeGameOverScreen()
    {
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); //Game Over screen is hidden at start
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        Debug.Log("Game Over!");

        // Show Game Over screen
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
            Debug.Log("Game Over screen activated.");
        }
    }

    public void RestartLevel()
    {
        Debug.Log("Restarting Level...");
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
