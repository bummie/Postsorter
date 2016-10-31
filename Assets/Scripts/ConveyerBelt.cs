using UnityEngine;
using System.Collections;

public class ConveyerBelt : MonoBehaviour {

    public bool isOn { get; set; }
    public float beltForce = 5f;

    void Start()
    {
        isOn = true;
    }
  
    // Flytter pakken på conveyerbeltet
    void OnTriggerStay(Collider post)
    {
        if (post.gameObject.tag.Equals("post"))
        {
            post.GetComponent<Rigidbody>().AddForce(Vector3.back * beltForce);
        }
        
    }
}
