using UnityEngine;
using System.Collections;

public class PostInfo : MonoBehaviour {

    public Vector3 size { get; set; }
    public int post_type { get; set; }
    public float paidPorto { get; set; }
    public float weight{ get; set; }
    public bool stamped { get; set; }

    void Start ()
    {
        size = Vector3.zero;
        post_type = 0;
        weight = paidPorto = 0f;
        stamped = false;
	}

    
	
}
