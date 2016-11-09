using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{
    public const int RUNNING = 0, PAUSED = 1, GAME_END = 2;
    private static int GAME_STATE;
    private Timer timer;

    private HUDHandler hud;

    void Start ()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDHandler>();
        timer = GetComponent<Timer>();
        setGameState(RUNNING);
	}

    void Update ()
    {
        switch (GAME_STATE)
        {
            case RUNNING:
                    // Setter HUDtiden til timertiden
                    timeRanOut();
                break;

            case PAUSED:
                // Do shit paused

                break;
            case GAME_END:
                // Do shit game ended
                break;
        }
    }

    public void setGameState(int state)
    {
        GAME_STATE = state;
        switch (GAME_STATE)
        {
            case RUNNING:

                timer.startTimer();
                break;

            case PAUSED:

                timer.stopStimer();
                break;

            case GAME_END:

                timer.stopStimer();
                break;
        }
    }

    private void timeRanOut()
    {
        hud.setTimer(timer.getPrettyTimeLeft());
        if (timer.getTimeLeft() < 0)
            setGameState(GAME_END);
    }
}
