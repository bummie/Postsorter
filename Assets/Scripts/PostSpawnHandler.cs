﻿using UnityEngine;
using System.Collections;

public class PostSpawnHandler : MonoBehaviour
{
    private Vector3 postSpawnPoint, postSpawnPointQueue;
    private GameObject postObjekter;
    private Random rand;

    void Start()
    {
        postObjekter = GameObject.FindGameObjectWithTag("post_objekter");
        postSpawnPoint = GameObject.FindGameObjectWithTag("post_spawnpoint").transform.position;
        postSpawnPointQueue = GameObject.FindGameObjectWithTag("post_spawnpoint_queue").transform.position;
        rand = new Random();

        createPackage();
        createLetterLarge();
        createLetterSmall();
    }

    // Randomly generated values post
    private GameObject createPackage()
    {
        if (postObjekter != null)
        {
            GameObject package = Instantiate(Resources.Load("Objects/Post/pakke") as GameObject);
            package.transform.parent = postObjekter.transform;
            package.transform.name = "Pakke";
            package.transform.position = postSpawnPoint;

            package.GetComponentInChildren<PostInfo>().size = new Vector3(100f, 100f, 100f);
            package.GetComponentInChildren<PostInfo>().weight = 210f;
            package.GetComponentInChildren<PostInfo>().paidPorto = 30f;
            package.GetComponentInChildren<PostInfo>().stamped = false;
            setStampColor(package);

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
            largeLetter.transform.name = "brev_stort";
            largeLetter.transform.position = postSpawnPoint;

            largeLetter.GetComponentInChildren<PostInfo>().size = new Vector3(21f, 0.2f, 29.7f);
            largeLetter.GetComponentInChildren<PostInfo>().weight = 48f;
            largeLetter.GetComponentInChildren<PostInfo>().paidPorto = 17f;
            largeLetter.GetComponentInChildren<PostInfo>().stamped = true;
            setStampColor(largeLetter);

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
            smallLetter.transform.name = "brev_lite";
            smallLetter.transform.position = postSpawnPoint;

            smallLetter.GetComponentInChildren<PostInfo>().size = new Vector3(21f, 0.2f, 14.8f);
            smallLetter.GetComponentInChildren<PostInfo>().weight = 21f;
            smallLetter.GetComponentInChildren<PostInfo>().paidPorto = 11f;
            smallLetter.GetComponentInChildren<PostInfo>().stamped = true;
            setStampColor(smallLetter);

            return smallLetter;
        }
        else
            return null;
    }

    // User defined post
    private GameObject createPackage(float paid, Vector3 size, float weight, bool stamped)
    {
        if (postObjekter != null)
        {
            GameObject package = Instantiate(Resources.Load("Objects/Post/pakke") as GameObject);
            package.transform.parent = postObjekter.transform;
            package.transform.name = "Pakke";
            package.transform.position = postSpawnPoint;

            package.GetComponentInChildren<PostInfo>().size = size;
            package.GetComponentInChildren<PostInfo>().weight = weight;
            package.GetComponentInChildren<PostInfo>().paidPorto = paid;
            package.GetComponentInChildren<PostInfo>().stamped = stamped;
            setStampColor(package);

            return package;
        }
        else
            return null;
    }

    private GameObject createLetterLarge(float paid, Vector3 size, float weight, bool stamped)
    {
        if (postObjekter != null)
        {
            GameObject largeLetter = Instantiate(Resources.Load("Objects/Post/brev_stort") as GameObject);
            largeLetter.transform.parent = postObjekter.transform;
            largeLetter.transform.name = "brev_stort";
            largeLetter.transform.position = postSpawnPoint;

            largeLetter.GetComponentInChildren<PostInfo>().size = size;
            largeLetter.GetComponentInChildren<PostInfo>().weight = weight;
            largeLetter.GetComponentInChildren<PostInfo>().paidPorto = paid;
            largeLetter.GetComponentInChildren<PostInfo>().stamped = stamped;
            setStampColor(largeLetter);

            return largeLetter;
        }
        else
            return null;
    }

    private GameObject createLetterSmall(float paid, Vector3 size, float weight, bool stamped)
    {
        if (postObjekter != null)
        {
            GameObject smallLetter = Instantiate(Resources.Load("Objects/Post/brev_lite") as GameObject);
            smallLetter.transform.parent = postObjekter.transform;
            smallLetter.transform.name = "brev_lite";
            smallLetter.transform.position = postSpawnPoint;

            smallLetter.GetComponentInChildren<PostInfo>().size = size;
            smallLetter.GetComponentInChildren<PostInfo>().weight = weight;
            smallLetter.GetComponentInChildren<PostInfo>().paidPorto = paid;
            smallLetter.GetComponentInChildren<PostInfo>().stamped = stamped;
            setStampColor(smallLetter);

            return smallLetter;
        }
        else
            return null;
    }

    private void setStampColor(GameObject postObject)
    {
        if (postObject.GetComponentInChildren<PostInfo>().stamped)
            postObject.GetComponentInChildren<PostInfo>().setStampColor(Color.green);
        else
            postObject.GetComponentInChildren<PostInfo>().setStampColor(Color.red);
    }
}
