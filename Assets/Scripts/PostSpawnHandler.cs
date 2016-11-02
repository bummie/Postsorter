using UnityEngine;
using System.Collections;

public class PostSpawnHandler : MonoBehaviour
{
    Vector3 postSpawnPoint, postSpawnPointQueue;

    void Start()
    {
        postSpawnPoint = GameObject.FindGameObjectWithTag("post_spawnpoint").transform.position;
        postSpawnPointQueue = GameObject.FindGameObjectWithTag("post_spawnpoint_queue").transform.position;
        createLetterSmall();
    }

    private GameObject createPackage()
    {
        return null;
    }

    private GameObject createLetterLarge()
    {
        return null;
    }

    private GameObject createLetterSmall()
    {
        GameObject smallLetter = Instantiate(Resources.Load("Objects/Post/brev_lite") as GameObject);
        smallLetter.transform.position = postSpawnPoint;
        return smallLetter;
    }
}
