using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDHandler : MonoBehaviour
{
    private Text textTimer, textWaves, textCorrect, textWrong, textPorto;

	void Start ()
    {
        textTimer = GameObject.FindGameObjectWithTag("HUD_Timer").GetComponent<Text>();
        textWaves = GameObject.FindGameObjectWithTag("HUD_Wave").GetComponent<Text>();
        textCorrect = GameObject.FindGameObjectWithTag("HUD_Correct").GetComponent<Text>();
        textWrong = GameObject.FindGameObjectWithTag("HUD_Wrong").GetComponent<Text>();
        textPorto = GameObject.FindGameObjectWithTag("HUD_Porto").GetComponent<Text>();
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
}
