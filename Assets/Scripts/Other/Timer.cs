using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour
{
    private float timerTime;
    private float timeLeft;

    private bool timerRunning = false;

    void Start()
    {
        timerTime = (5f * 60f);
        timeLeft = timerTime;
    }

    void Update()
    {
        if (timerRunning)
        {
            timeLeft -= Time.deltaTime;
        }
    }

    // Starter timeren
    public void startTimer()
    {
        timerRunning = true;
    }

    // Stoppe timeren
    public void stopStimer()
    {
        timerRunning = false;
    }

    // Tilbakestille timeren
    public void resetTimer()
    {
        timeLeft = timerTime;
    }

    // Sette ny tid til timeren
    public void setTimerTime(float time)
    {
        timerTime = time;
    }

    // Returnere float antall sekunder igjen av timeren
    public float getTimeLeft()
    {
        return timeLeft;
    }

    // Returnerer tiden som er igjen formartert 05m:11s
    public string getPrettyTimeLeft()
    {
        TimeSpan time = TimeSpan.FromSeconds(timeLeft);
        string answer = string.Format("{0:D2}:{1:D2}",
                time.Minutes,
                time.Seconds);
        return answer;
    }

}
