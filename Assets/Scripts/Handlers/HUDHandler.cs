using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHandler : MonoBehaviour
{

    //HUD
    private Text textTimer, textWaves, textCorrect, textWrong, textPorto, textNoti;
    private GameObject Notification;

    //GameOver
    public Text gameOverTextTitle, gameOverTextTime, gameOverTextPorto, gameOverTextPostCorrect, gameOverTextPostWrong, gameOverTextStampedCorrect, gameOverTextStampedWrong, gameOverTextMoney;
    public GameObject panelGameOver;

    // Notifcation timer
    private float timeLeft;
    private bool timerRunning = false;

    void Start ()
    {
        // HUD
        textTimer = GameObject.FindGameObjectWithTag("HUD_Timer").GetComponent<Text>();
        textWaves = GameObject.FindGameObjectWithTag("HUD_Wave").GetComponent<Text>();
        textCorrect = GameObject.FindGameObjectWithTag("HUD_Correct").GetComponent<Text>();
        textWrong = GameObject.FindGameObjectWithTag("HUD_Wrong").GetComponent<Text>();
        textPorto = GameObject.FindGameObjectWithTag("HUD_Porto").GetComponent<Text>();
        Notification = GameObject.FindGameObjectWithTag("HUD_Noti");

        // Notification
        textNoti = Notification.GetComponentInChildren<Text>();
        displayNotification(false);
        displayGameOver(false);
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

    public void displayGameOver(bool display)
    {
        if (panelGameOver != null)
        {
            panelGameOver.SetActive(display);
        }
    }

    public void setTextScoreTitle(string text)
    {
        if (gameOverTextTitle != null)
            gameOverTextTitle.text = text;
    }

    public void setTextScoreTime(string text)
    {
        if (gameOverTextTime != null)
            gameOverTextTime.text = text;
    }

    public void setTextScorePorto(string text)
    {
        if (gameOverTextPorto != null)
            gameOverTextPorto.text = text;
    }

    public void setTextScorePostCorrect(string text)
    {
        if (gameOverTextPostCorrect != null)
            gameOverTextPostCorrect.text = text;
    }

    public void setTextScorePostWrong(string text)
    {
        if (gameOverTextPostWrong != null)
            gameOverTextPostWrong.text = text;
    }

    public void setTextScoreStampedCorrect(string text)
    {
        if (gameOverTextStampedCorrect != null)
            gameOverTextStampedCorrect.text = text;
    }

    public void setTextScoreStampedWrong(string text)
    {
        if (gameOverTextStampedWrong != null)
            gameOverTextStampedWrong.text = text;
    }

    public void setTextScoreMoney(string text)
    {
        if (gameOverTextMoney != null)
            gameOverTextMoney.text = text;
    }
}