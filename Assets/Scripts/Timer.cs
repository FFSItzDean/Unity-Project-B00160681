//B00160681 Dean Smith
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] public TMP_Text lapText;
    static float timer;
    public static bool timerStarted;  
    private static float bonusTime = 20f;  

    void Start()
    {
        ResetTimer();
    }

    void OnEnable()
    {
        ResetTimer();
    }

    private void ResetTimer()
    {
        timer = 60f;
        timerStarted = false;  
        bonusTime = 20f;  

        //initialize displays
        if (timerText != null)
        {
            timerText.text = "1:00";
        }
        if (lapText != null)
        {
            lapText.text = "Lap: 1/1";
        }
    }

    public static void AddTime(float seconds)
    {
        Debug.Log($"Current timer before adding: {timer}");  
        timer += seconds;
        Debug.Log($"Added {seconds} seconds. New timer value: {timer}");  
    }

    public static float GetBonusTime()
    {
        return bonusTime;
    }

    public static void ReduceBonusTime()
    {
        bonusTime = Mathf.Max(4f, bonusTime - 4f);  
        Debug.Log($"Reduced bonus time to: {bonusTime}");  
    }

    public static void UpdateLapText(int currentLap, float totalLaps)
    {
        Timer timerInstance = FindObjectOfType<Timer>();
        if (timerInstance != null && timerInstance.lapText != null)
        {
            timerInstance.lapText.text = $"LAP {currentLap}/{totalLaps}";
        }
    }

    void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime * 0.08f;  

            if (timer <= 0)
            {
                timer = 0;
                timerStarted = false;
                GameManager.Instance.GameOver("Time's Up!");
                return;
            }

            //update display
            if (timerText != null)
            {
                int minutes = Mathf.FloorToInt(timer / 60);
                int seconds = Mathf.FloorToInt(timer - minutes * 60);
                string time = string.Format("{0:0}:{1:00}", minutes, seconds);
                timerText.text = time;
            }
        }
    }
}
