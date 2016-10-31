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
                if (hit.transform.tag.Equals("post"))
                {
                    postObj = hit.transform.gameObject;
                    ignoreAllPost(true);

                    mouseHitPost = true;
                    lockRotation = true;
                    displayInfo.GetComponent<DisplayPostInfoHandler>().setPostInfo(postObj);
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
                    //Debug.Log(ray.GetPoint(100f));
                    if (hit.transform.tag.Equals("post_ray_collider"))
                    {
                        Vector3 nyPos = new Vector3(hit.point.x, hit.point.y + 3f, hit.point.z);
                        postObj.transform.position = nyPos;
                        if (lockRotation)
                            postObj.transform.eulerAngles = Vector3.zero;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (postObj == null)
                mouseHitPost = false;

            if (mouseHitPost)
            {
                ignoreAllPost(false);
                mouseHitPost = false;
                lockRotation = false;
            }
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
}
