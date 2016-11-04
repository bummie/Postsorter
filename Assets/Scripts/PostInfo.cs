using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PostInfo : MonoBehaviour
{
    public Vector3 size { get; set; }
    public int post_type { get; set; }
    public float paidPorto { get; set; }
    public float weight{ get; set; }
    public bool stamped { get; set; }

    public void setStampColor(Color col)
    {
        gameObject.GetComponentInChildren<Image>().color = col;
    }
}
