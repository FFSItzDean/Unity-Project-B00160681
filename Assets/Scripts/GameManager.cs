//B00160681 Dean Smith
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject gameOverPanel;
    public TMP_Text gameOverText;
    private bool isGameOver = false;
    
    private void Awake()
    {
        //ensure only one game manager exists
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
        //reset state
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        Time.timeScale = 1f;
        isGameOver = false;
    }

    private void Update()
    {
        //handle scene reload with key press
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            RestartGame();
        }
    }

    public void GameOver(string reason)
    {
        Debug.Log("Game Over Called: " + reason); //debug game over info
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            if (gameOverText != null)
            {
                gameOverText.text = reason + "\nPress '2' to restart";
            }
        }
        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        //reload current scene and reset game state
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
