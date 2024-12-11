//B00160681 Dean Smith
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private Timer timer;

    [Header("Checkpoints")]
    public GameObject startFinishCheckpoint;  //main checkpoint for start and finish line
    public GameObject[] checkpoints;  //intermediate checkpoints

    [Header("Settings")]
    public float laps = 1;  //initial target lap count

    [Header("information")]
    private float currentCheckpoint;
    private float currentLap;
    private bool started;
    private bool finished;

    private void Start()
    {
        ResetLaps();
    }

    private void OnEnable()
    {
        ResetLaps();
    }

    private void ResetLaps()
    {
        currentCheckpoint = 0;
        currentLap = 1;
        laps = 1;  //reset target lap count

        started = false;
        finished = false;

        //initialize timer and lap display
        timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            Timer.UpdateLapText(1, 1);
        }
        else
        {
            Debug.LogWarning("timer not found in scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger entered by {other.gameObject.name} with tag {other.tag}");  //debug checkpoint info
        if (other.CompareTag("Checkpoint"))
        {
            GameObject thisCheckpoint = other.gameObject;

            //handle start/finish line checkpoint
            if (thisCheckpoint == startFinishCheckpoint)
            {
                if (!started)
                {
                    //initialize race start
                    print("Started");
                    started = true;
                    Timer.timerStarted = true;
                    Timer.UpdateLapText((int)currentLap, (int)laps);
                }
                else if (currentCheckpoint == checkpoints.Length)
                {
                    //complete current lap and start next
                    currentLap++;
                    laps++;  //increment target laps with current lap
                    currentCheckpoint = 0;
                    Timer.UpdateLapText((int)currentLap, (int)laps);
                    Timer.ReduceBonusTime();  //reduce time bonus for next lap
                    print($"Started lap {currentLap}");
                }
                return;
            }

            //handle intermediate checkpoints
            for (int i = 0; i < checkpoints.Length; i++)
            {
                if (finished)
                    return;

                if (thisCheckpoint == checkpoints[i] && i == currentCheckpoint)
                {
                    Debug.Log($"Hit checkpoint {i}");  //debug checkpoint progress
                    print("Correct checkpoint");
                    currentCheckpoint++;
                    Timer.AddTime(Timer.GetBonusTime());  //add time bonus for hitting checkpoint

                    //check if lap is complete
                    if (currentCheckpoint == checkpoints.Length)
                    {
                        currentLap++;
                        laps++;  //increment target laps with current lap
                        currentCheckpoint = 0;
                        Timer.UpdateLapText((int)currentLap, (int)laps);
                        Timer.ReduceBonusTime();  //reduce time bonus for next lap
                        print($"Started lap {currentLap}");
                    }
                }
                else if (thisCheckpoint == checkpoints[i] && i != currentCheckpoint)
                {
                    print("Incorrect Checkpoint");
                }
            }
        }
    }
}
