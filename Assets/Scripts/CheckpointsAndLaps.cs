//B00160681 Dean Smith
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    private Timer timer;

    [Header("Checkpoints")]
    public GameObject startFinishCheckpoint;  //single checkpoint for start/finish
    public GameObject[] checkpoints;  //other checkpoints

    [Header("Settings")]
    public float laps = 1;

    [Header("information")]
    private float currentCheckpoint;
    private float currentLap;
    private bool started;
    private bool finished;

    private void Start(){
        currentCheckpoint = 0;
        currentLap = 1;

        started = false;
        finished = false;

        timer = FindObjectOfType<Timer>();
        Timer.UpdateLapText((int)currentLap, (int)laps);
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Checkpoint")){
            
            GameObject thisCheckpoint = other.gameObject;

            //handle start/finish checkpoint
            if (thisCheckpoint == startFinishCheckpoint)
            {
                if (!started)
                {
                    //start race
                    print("Started");
                    started = true;
                    Timer.timerStarted = true;
                    Timer.UpdateLapText((int)currentLap, (int)currentLap);
                }
                else if (currentCheckpoint == checkpoints.Length)
                {
                    //complete lap
                    currentLap++;
                    currentCheckpoint = 0;
                    Timer.UpdateLapText((int)currentLap, (int)currentLap);
                    Timer.ReduceBonusTime();  //reduce bonus time for next lap
                    print($"Started lap {currentLap}");
                }
                return;
            }

            //handle other checkpoints
            for (int i = 0; i < checkpoints.Length; i++){
                if (finished)
                    return;

                if (thisCheckpoint == checkpoints[i] && i == currentCheckpoint){
                    Debug.Log($"Hit checkpoint {i}");  //debug
                    print("Correct checkpoint");
                    currentCheckpoint++;
                    Timer.AddTime(Timer.GetBonusTime());  //add current bonus time
                    
                    //next lap
                    if (currentCheckpoint == checkpoints.Length){
                        currentLap++;
                        currentCheckpoint = 0;
                        Timer.UpdateLapText((int)currentLap, (int)currentLap);
                        Timer.ReduceBonusTime();  //reduce bonus time for next lap
                        print($"Started lap {currentLap}");
                    }
                }
                else if (thisCheckpoint == checkpoints[i] && i != currentCheckpoint){
                    print("Incorrect Checkpoint");
                }
            }
        }
    }
}
