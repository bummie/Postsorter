using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHandler : MonoBehaviour
{
    private Text textTimer, textWaves, textCorrect, textWrong, textPorto, textNoti;
    private GameObject Notification;

    // Notifcation timer
    private float timeLeft;
    private bool timerRunning = false;

    void Start ()
    {
        textTimer = GameObject.FindGameObjectWithTag("HUD_Timer").GetComponent<Text>();
        textWaves = GameObject.FindGameObjectWithTag("HUD_Wave").GetComponent<Text>();
        textCorrect = GameObject.FindGameObjectWithTag("HUD_Correct").GetComponent<Text>();
        textWrong = GameObject.FindGameObjectWithTag("HUD_Wrong").GetComponent<Text>();
        textPorto = GameObject.FindGameObjectWithTag("HUD_Porto").GetComponent<Text>();

        Notification = GameObject.FindGameObjectWithTag("HUD_Noti");
        textNoti = Notification.GetComponentInChildren<Text>();

        displayNotification(false);
        timeLeft = 0f;
    }

    void Update()
    {
        if (timerRunning)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timerRunning = false;
                displayNotification(false);
            }
        }
    }

    public void setTimer(string text)
    {
        if(textTimer != null)
            textTimer.text = text;
    }

    public void setWave(string text)
    {
        textWaves = GameObject.FindGameObjectWithTag("HUD_Wave").GetComponent<Text>();
        if (textWaves != null)
            textWaves.text = text;
    }

    public void setCorrect(string text)
    {
        if (textCorrect != null)
            textCorrect.text = text;
    }

    public void setWrong(string text)
    {
        if (textWrong != null)
            textWrong.text = text;
    }
    public void setPorto(string text)
    {
        if (textPorto != null)
            textPorto.text = text;
    }

    public void displayNotification(bool showNotifi)
    {
        if (Notification != null)
         Notification.SetActive(showNotifi);
    }

    public void displayNotification(string text, float timer)
    {  if(Notification != null)
        {
        timeLeft = timer;
        Notification.SetActive(true);
        setNotification(text);
        timerRunning = true;
        }
    }

    public void setNotification(string text)
    {
        if (textNoti != null)
            textNoti.text = text;
    }
}