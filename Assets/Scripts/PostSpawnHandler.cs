using UnityEngine;
using System.Collections;

public class PostSpawnHandler : MonoBehaviour
{
    private Vector3 postSpawnPoint, postSpawnPointQueue;
    private GameObject postObjekter;

    void Start()
    {
        postObjekter = GameObject.FindGameObjectWithTag("post_objekter");
        postSpawnPoint = GameObject.FindGameObjectWithTag("post_spawnpoint").transform.position;
        postSpawnPointQueue = GameObject.FindGameObjectWithTag("post_spawnpoint_queue").transform.position;
        createLetterSmall();
    }

    private GameObject createPackage()
    {
        if (postObjekter != null)
        {
            GameObject package = Instantiate(Resources.Load("Objects/Post/pakke") as GameObject);
            package.transform.parent = postObjekter.transform;
            package.transform.position = postSpawnPoint;
            package.GetComponent<PostInfo>().size = new Vector3(21f, 0.2f, 29.7f);
            package.GetComponent<PostInfo>().weight = 21f;
            package.GetComponent<PostInfo>().paidPorto = 11f;
            package.GetComponent<PostInfo>().stamped = true;

            return package;
        }
        else
            return null;
    }

    private GameObject createLetterLarge()
    {
        if (postObjekter != null)
        {
            GameObject largeLetter = Instantiate(Resources.Load("Objects/Post/brev_stort") as GameObject);
            largeLetter.transform.parent = postObjekter.transform;
            largeLetter.transform.position = postSpawnPoint;
            largeLetter.GetComponent<PostInfo>().size = new Vector3(21f, 0.2f, 29.7f);
            largeLetter.GetComponent<PostInfo>().weight = 48f;
            largeLetter.GetComponent<PostInfo>().paidPorto = 17f;
            largeLetter.GetComponent<PostInfo>().stamped = true;

            return largeLetter;
        }
        else
            return null;
    }

    private GameObject createLetterSmall()
    {
        if (postObjekter != null)
        {
            GameObject smallLetter = Instantiate(Resources.Load("Objects/Post/brev_lite") as GameObject);
            smallLetter.transform.parent = postObjekter.transform;
            smallLetter.transform.position = postSpawnPoint;
            smallLetter.GetComponent<PostInfo>().size = new Vector3(21f, 0.2f, 14.8f);
            smallLetter.GetComponent<PostInfo>().weight = 21f;
            smallLetter.GetComponent<PostInfo>().paidPorto = 11f;
            smallLetter.GetComponent<PostInfo>().stamped = true;

            return smallLetter;
        }
        else
            return null;
    }
}
