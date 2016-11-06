using UnityEngine;
using System.Collections;

public class ConveyerBelt : MonoBehaviour {

    public bool isOn { get; set; }
    public float beltForce = 12f;

    void Start()
    {
        isOn = true;
    }
  
    // Flytter pakken på conveyerbeltet
    void OnTriggerStay(Collider post)
    {
        if (post.gameObject.tag.Equals("post") || post.gameObject.tag.Equals("garbage"))
        {
            //post.GetComponent<Rigidbody>().AddForce(Vector3.back * beltForce * post.GetComponent<Rigidbody>().mass);
            post.GetComponent<Rigidbody>().velocity = Vector3.back * beltForce;
        }
        
    }

    void OnTriggerExit(Collider post)
    {
        post.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
