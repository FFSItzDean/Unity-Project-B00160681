//B00160681 Dean Smith
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //load game scene (scene index 1)
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        //quit application
        Debug.Log("quit game");
        Application.Quit();
    }
}
