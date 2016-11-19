using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{
    public const int STARTED = 0, RUNNING = 1, PAUSED = 2, GAME_END = 3, WAVE_FINISHED = 4;
    private static int GAME_STATE;
    private bool startedInit = false;
    private Timer timer;
    private DataIO IO;
    private PostWaves wave;
    private HUDHandler hud;
    private int[] districtWaves;

    void Start ()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDHandler>();
        timer = GetComponent<Timer>();
        IO = new DataIO();
        wave = GetComponent<PostWaves>();
	}

    void Update ()
    {
       if(!startedInit)
            setGameState(STARTED);

        switch (GAME_STATE)
        {
            case STARTED:
                if (!startedInit)
                {
                    spawnPost();
                    setGameState(RUNNING);
                    startedInit = true;
                }
                // Setter HUDtiden til timertiden
                break;

            case RUNNING:
                    // Setter HUDtiden til timertiden
                    timeRanOut();
                if (wave.isWaveDone())
                    setGameState(WAVE_FINISHED);
                break;

            case PAUSED:
                // Do shit paused

                break;
            case GAME_END:
                // Do shit game ended
                break;

            case WAVE_FINISHED:
                // Do shit game ended
                break;
        }
    }

    public void setGameState(int state)
    {
        GAME_STATE = state;
        switch (GAME_STATE)
        {
            case STARTED:
               
                break;

            case RUNNING:
                Debug.Log("Running");

                timer.startTimer();
                break;

            case PAUSED:
                Debug.Log("Paused");

                timer.stopStimer();
                break;

            case GAME_END:
                Debug.Log("Game_ended");

                timer.stopStimer();
                break;

            case WAVE_FINISHED:
                Debug.Log("Wave finished");
                if (isLastWave())
                    setGameState(GAME_END);
                else
                {
                    setGameState(RUNNING);
                    wave.setCurrentWave(wave.getCurrentWave()+1);
                    spawnPost();
                }

                break;
        }
    }

    private void timeRanOut()
    {
        hud.setTimer(timer.getPrettyTimeLeft());
        if (timer.getTimeLeft() <= 0)
        {
            setGameState(GAME_END);
            timer.stopStimer();
        }
    }

    private void spawnPost()
    {
        hud.setWave((wave.getCurrentWave()+1) + "/" + wave.getAmountWaves());
        wave.spawnWave();
    }

    private bool isLastWave()
    {
        if (wave.getCurrentWave() + 1 > wave.getAmountWaves())
        {
            Debug.Log("Last wave finished");
            return true;
        }
        else
            return false;
    }
}
