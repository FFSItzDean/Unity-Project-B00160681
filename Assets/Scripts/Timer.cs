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
    static float timer;
    [SerializeField] public TMP_Text lapText;
    public static bool timerStarted = false;
    private static float bonusTime = 20f;  //starting bonus time

    void Start()
    {
        timer = 60f;
        timerStarted = false;
        bonusTime = 20f;  //reset bonus time
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
        bonusTime = Mathf.Max(4f, bonusTime - 4f);  //minimum 4 seconds bonus
        Debug.Log($"Reduced bonus time to: {bonusTime}");
    }

    public static void UpdateLapText(int currentLap, float totalLaps)
    {
        FindObjectOfType<Timer>().lapText.text = $"Lap: {currentLap}/{currentLap}";
    }

    void Update()
    {
        if (timerStarted){
            timer -= Time.deltaTime * 0.08f;  //speed multiplier

            if (timer <= 0)
            {
                GameManager.Instance.GameOver("Time's Up!");
                return;
            }

            //update display
            int minutes = Mathf.FloorToInt(timer / 60);
            int seconds = Mathf.FloorToInt(timer - minutes * 60);
            string time = string.Format("{0:0}:{1:00}", minutes, seconds);
            timerText.text = time;
        }
    }
}
