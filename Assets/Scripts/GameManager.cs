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
        //check instance
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
        gameOverPanel.SetActive(false);
        Time.timeScale = 1f;
        isGameOver = false;
    }

    private void Update()
    {
        //restart input
        if (isGameOver && Input.GetKeyDown(KeyCode.Alpha2))
        {
            RestartGame();
        }
    }

    public void GameOver(string reason)
    {
        Debug.Log("Game Over Called: " + reason);  //debug
        gameOverPanel.SetActive(true);
        gameOverText.text = reason + "\nPress '2' to restart";
        Time.timeScale = 0f;
        isGameOver = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
