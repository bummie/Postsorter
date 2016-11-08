using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PostSpawnHandler : MonoBehaviour
{
    private Vector3 postSpawnPoint, postSpawnPointQueue;
    private GameObject postObjekter, portoHandler;
    private PostMapReader mapReader;

    // Timed post spawning
    private GameObject[] queuedPost;
    private int queuedPostIndex = 0;
    public float spawnTimeFixed = 2f;
    private float spawnTime = 0f;
    private bool spawnPost = false;

    void Start()
    {
        mapReader = new PostMapReader();
        portoHandler = GameObject.FindGameObjectWithTag("PortoHandler");
        postObjekter = GameObject.FindGameObjectWithTag("post_objekter");
        postSpawnPoint = GameObject.FindGameObjectWithTag("post_spawnpoint").transform.position;
        postSpawnPointQueue = GameObject.FindGameObjectWithTag("post_spawnpoint_queue").transform.position;

        queuedPost = null;

        spawnPostFromMap(0, 0);
    }

    void Update()
    {
        if (spawnPost)
        {
            spawnTime -= Time.deltaTime;
            if (spawnTime <= 0.0f)
            {
                spawnQueuedPost();
                spawnTime = spawnTimeFixed;
            }
        }
    }

    void spawnQueuedPost()
    {
        queuedPost[queuedPostIndex].transform.position = postSpawnPoint;
        queuedPost[queuedPostIndex].layer = 0;
        queuedPost[queuedPostIndex].GetComponent<Rigidbody>().useGravity = true;

        if (queuedPost.Length <= (queuedPostIndex+1))
        {
            spawnPost = false;
            queuedPostIndex = 0;
        }
        else
            queuedPostIndex++;
    }

    public void spawnPostFromMap(int dag, int district)
    {
        string[] typePost = mapReader.returnPost(dag, district);
        GameObject[] newSpawnedPost = new GameObject[typePost.Length];
        for(int i = 0; i < typePost.Length; i++)
        {
            newSpawnedPost[i] = createPost(typePost[i]);
            if (newSpawnedPost[i].tag.Equals("post"))
            {
                mapReader.setPostValues(newSpawnedPost[i], dag, district, i);
                setStampColor(newSpawnedPost[i]);
            }
        }
        queuedPost = newSpawnedPost;
        spawnPost = true;
    }

    private GameObject createPost(string type)
    {
        if (postObjekter != null)
        {
            if (!type.Equals("garbage"))
            {
                GameObject post = Instantiate(Resources.Load("Objects/Post/" + type) as GameObject);
                post.transform.parent = postObjekter.transform;
                post.transform.name = type;
                post.transform.position = postSpawnPointQueue;
                post.layer = 2;
                post.GetComponent<Rigidbody>().useGravity = false;

                return post;
            }
            else
            {
                string[] garbageTypes = {"garb_bottle", "garb_poop", "garb_paper", "garb_boot" };
                string garbType = garbageTypes[Random.Range(0, garbageTypes.Length)];
                GameObject post = Instantiate(Resources.Load("Objects/Garbage/" + garbType) as GameObject);
                post.transform.parent = postObjekter.transform;
                post.transform.name = garbType;
                post.transform.position = postSpawnPointQueue;
                post.layer = 2;
                post.GetComponent<Rigidbody>().useGravity = false;

                return post;
            }
            
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
