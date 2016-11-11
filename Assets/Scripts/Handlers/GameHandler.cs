using UnityEngine;
using System.Collections;

public class GameHandler : MonoBehaviour
{
    public const int STARTED = 0, RUNNING = 1, PAUSED = 2, GAME_END = 3;
    private static int GAME_STATE;

    private Timer timer;
    private DataIO IO;
    private HUDHandler hud;
    private PostSpawnHandler postSpawn;
    private int[] districtWaves;

    void Start ()
    {
        postSpawn = GameObject.FindGameObjectWithTag("PostSpawnHandler").GetComponent<PostSpawnHandler>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUDHandler>();
        timer = GetComponent<Timer>();
        IO = GetComponent<DataIO>();

        setGameState(STARTED);
	}

    void Update ()
    {
        switch (GAME_STATE)
        {

            case STARTED:
                // Setter HUDtiden til timertiden
                break;

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
            case STARTED:
                IO.firstLoad(); // TRUE FALSE
                districtWaves = IO.getUnlockedDistricts();
                hud.setWave("1/" + districtWaves.Length);
                setGameState(RUNNING);
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
        }
    }

    private void timeRanOut()
    {
        hud.setTimer(timer.getPrettyTimeLeft());
        if (timer.getTimeLeft() < 0)
            setGameState(GAME_END);
    }
}
