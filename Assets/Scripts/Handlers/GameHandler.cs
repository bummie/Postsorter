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

    private bool gameOverTimeRanOut = false;

    public GameObject scoreH;

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
                nextDay();
                gameOverUI();
                timer.stopStimer();
                break;

            case WAVE_FINISHED:
                Debug.Log("Wave finished");
                if (isLastWave())
                    setGameState(GAME_END);
                else
                {
                    setGameState(RUNNING);
                    // FIkse her sjekke om det er en neste wave
                    wave.setCurrentWave(wave.getCurrentWave() + 1);
                    spawnPost();
                }

                break;
        }
    }

    public void restartGame()
    {
        setGameState(RUNNING);
        wave.setCurrentWave(0);
        hud.displayGameOver(false);
        timer.resetTimer();
        scoreH.GetComponent<ScoreHandler>().resetScore();
        spawnPost();
    }

    private void timeRanOut()
    {
        hud.setTimer(timer.getPrettyTimeLeft());
        if (timer.getTimeLeft() <= 0)
        {
            setGameState(GAME_END);
            gameOverTimeRanOut = true;
            timer.stopStimer();
        }
    }

    private void spawnPost()
    {
        Debug.Log("Day " + IO.getCurrentDay() + ", " + IO.getSeason());
        // Prøve snu om rekkefølgen her fikse 3/2 bug
        hud.setWave((wave.getCurrentWave()+1) + "/" + wave.getAmountWaves());
        hud.displayNotification("Next wave from " + IO.getDistrictName(wave.getCurrentDistrict()), 2.3f);
        wave.spawnWave();
    }

    private bool isLastWave()
    {
        if (wave.getCurrentWave() + 1 > wave.getAmountWaves())
        {
            return true;
        }
        else
            return false;
    }

    private void nextDay()
    {
        if (IO.getCurrentDay() >= 5)
        {
            IO.setCurrentDay(0);
            if (IO.getSeason() >= 3)
                IO.setSeason(0);
            else
                IO.setSeason(IO.getSeason() + 1);
        }
        else
        {
            IO.setCurrentDay(IO.getCurrentDay() + 1);
        }  
    }

    public void gameOverUI()
    {
        hud.displayGameOver(true);
        if (scoreH != null)
        {
            ScoreHandler sH = scoreH.GetComponent<ScoreHandler>();
            int moneyGained = sH.calculateGainedMoney();
            IO.setMoney(IO.getMoney() + moneyGained);

            sH.printScore();
            int correct = sH.amount_Large + sH.amount_Small + sH.amount_Package;
            if(gameOverTimeRanOut)
                hud.setTextScoreTitle("Time ran out!");
            else
                hud.setTextScoreTitle("Workday over");
            hud.setTextScoreTime(timer.getPrettyTimeLeft());
            hud.setTextScorePorto(sH.amount_Porto.ToString());
            hud.setTextScorePostCorrect(correct.ToString());
            hud.setTextScorePostWrong(sH.amount_Wrong.ToString());
            hud.setTextScoreStampedCorrect(sH.amount_Stamped.ToString());
            hud.setTextScoreStampedWrong(sH.amount_notStamped.ToString());
            hud.setTextScoreMoney("$" + moneyGained.ToString());
        }
    }
}
