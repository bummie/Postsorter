using UnityEngine;
using System.Collections;

public class PostWaves : MonoBehaviour {

    private PostSpawnHandler postSpawn;
    private DataIO IO;
    private GameObject gH, pSH;

    private int[] districtWaves;
    private int currentWave = 0;
    private bool waveDone = true;

    void Start ()
    {
        gH = gameObject;
        pSH = GameObject.FindGameObjectWithTag("PostSpawnHandler");
        postSpawn = pSH.GetComponent<PostSpawnHandler>();
        IO = new DataIO();
    }

    void Update ()
    {
        initDistrictWaves();
        // Sjekker om waven er ferdig
        if (waveDone == false)
        {
            if (!postExist())
                waveDone = true;
        }
    }

    public bool isWaveDone()
    {
        return waveDone;
    }

    private void initDistrictWaves()
    {
        if (districtWaves == null)
            districtWaves = IO.getUnlockedDistricts();
    }

    public bool postExist()
    {
        bool ex = false;

        if (GameObject.FindGameObjectsWithTag("post").Length > 0 || GameObject.FindGameObjectsWithTag("garbage").Length > 0)
            ex = true;
        return ex;
    }

    // Spawner wave
    public void spawnWave()
    {
        initDistrictWaves();
        int day = IO.getCurrentDay();

        if(districtWaves != null)
            postSpawn.spawnPostFromMap(day, districtWaves[currentWave]);

        waveDone = false;
    }

    public void setCurrentWave(int wave)
    {
        currentWave = wave;
    }

    public int getCurrentWave()
    {
        return currentWave+1;
    }

    public int getAmountWaves()
    {
        initDistrictWaves();

        if (districtWaves != null)
            return districtWaves.Length;
        else
            return -1;
    }
}
