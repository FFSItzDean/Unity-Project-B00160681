//B00160681 Dean Smith
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    [SerializeField] private CarController carController;

    void Start()
    {
        //disable car controls and timer at start
        if (carController != null)
        {
            carController.enabled = false;
        }
        Timer.timerStarted = false;
    }

    void Update()
    {
        //start game when space is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (startText != null)
            {
                startText.SetActive(false);
            }
            if (carController != null)
            {
                carController.enabled = true;
            }
            //Timer will start when hitting the start checkpoint instead
        }
    }
}
