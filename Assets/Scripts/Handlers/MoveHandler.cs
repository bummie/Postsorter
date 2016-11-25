using UnityEngine;
using System.Collections;

public class MoveHandler : MonoBehaviour {

    private bool mouseHitPost = false, lockRotation = false;
    private GameObject postObj, displayInfo;
    private Vector3 lastObjPos;

    void Start()
    {
        displayInfo = GameObject.FindGameObjectWithTag("DisplayInfo");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500.0f))
            {
                if (hit.transform.tag.Equals("post") || hit.transform.tag.Equals("garbage"))
                {
                        postObj = hit.transform.gameObject;
                        ignoreAllPost(true);
                        ignoreAllGarbage(true);
                        postObj.GetComponent<Collider>().isTrigger = true;

                        mouseHitPost = true;
                        lockRotation = true;
                        displayInfo.GetComponent<DisplayPostInfoHandler>().setSelected(postObj);
                    GetComponent<AudioSource>().Play(); // Fikse her legge til i lydhandleren YOOYO
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (mouseHitPost)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 500.0f))
                {
                    if (hit.transform.tag.Equals("post_ray_collider"))
                    {
                        Vector3 nyPos = new Vector3(hit.point.x, hit.point.y + 3f, hit.point.z);
                        postObj.transform.position = nyPos;
                        if (lockRotation)
                            postObj.transform.eulerAngles = Vector3.zero;
                    }
                    else
                    {
                        mouseUp();
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            mouseUp();
        }
    }

    private void mouseUp()
    {
        if (postObj == null)
            mouseHitPost = false;

        if (mouseHitPost)
        {
            ignoreAllPost(false);
            ignoreAllGarbage(false);
            postObj.GetComponent<Collider>().isTrigger = false;
            mouseHitPost = false;
            lockRotation = false;
        }
    }
    public void ignoreAllPost(bool ignore)
    {
        GameObject[] postObjekter = GameObject.FindGameObjectsWithTag("post");
        foreach (GameObject g in postObjekter)
        {
            if (ignore)
                g.layer = 2;
            else
                g.layer = 0;
        }
    }

    public void ignoreAllGarbage(bool ignore)
    {
        GameObject[] garbageObjekter = GameObject.FindGameObjectsWithTag("garbage");
        foreach (GameObject g in garbageObjekter)
        {
            if (ignore)
                g.layer = 2;
            else
                g.layer = 0;
        }
    }
}
