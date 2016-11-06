using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostSpawnHandler : MonoBehaviour
{
    private Vector3 postSpawnPoint, postSpawnPointQueue;
    private GameObject postObjekter, portoHandler;
    private PostMapReader mapReader;

    void Start()
    {
        mapReader = new PostMapReader();
        portoHandler = GameObject.FindGameObjectWithTag("PortoHandler");
        postObjekter = GameObject.FindGameObjectWithTag("post_objekter");
        postSpawnPoint = GameObject.FindGameObjectWithTag("post_spawnpoint").transform.position;
        postSpawnPointQueue = GameObject.FindGameObjectWithTag("post_spawnpoint_queue").transform.position;

        spawnPostFromMap(0, 0);
    }

    public void spawnPostFromMap(int dag, int district)
    {
        string[] typePost = mapReader.returnPost(dag, district);
        GameObject[] newSpawnedPost = new GameObject[typePost.Length];
        for(int i = 0; i < typePost.Length; i++)
        {
            newSpawnedPost[i] = createPost(typePost[i]);
            mapReader.setPostValues(newSpawnedPost[i], dag, district, i);
            setStampColor(newSpawnedPost[i]);
        }
    }

    private GameObject createPost(string type)
    {
        if (postObjekter != null)
        {
            GameObject post = Instantiate(Resources.Load("Objects/Post/" + type) as GameObject);
            post.transform.parent = postObjekter.transform;
            post.transform.name = type;
            post.transform.position = postSpawnPoint;

            return post;
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

    private void setRandomValuesPackage(GameObject package)
    {
        if(package != null)
        {
            Vector3 ranSize = new Vector3(Random.Range(10f, 60f), Random.Range(1f, 60f), Random.Range(10f, 60f));
            float weight = Random.Range(15f, 2300f);
            float paid = Random.Range(0, 11);
            paid = portoHandler.GetComponent<PortoHandler>().getAllPortoPrice()[(int)paid];
            package.GetComponentInChildren<PostInfo>().size = ranSize;
            package.GetComponentInChildren<PostInfo>().weight = weight;
            package.GetComponentInChildren<PostInfo>().paidPorto = paid;
            package.GetComponentInChildren<PostInfo>().stamped = false;
        }
       
    }
}
