using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPostInfoHandler : MonoBehaviour {

    private GameObject selectedObject;
    private Text money, size, weight, stamp;

	void Start ()
    {
        money = GameObject.Find("text_money").GetComponent<Text>();
        size = GameObject.Find("text_ruler").GetComponent<Text>();
        weight = GameObject.Find("text_weight").GetComponent<Text>();
        stamp = GameObject.Find("text_stamp").GetComponent<Text>();
    }

    public void setSelected(GameObject postObj)
    {
        selectedObject = postObj;
        updatePostInfoDisplay();
    }

    public void setSelectedStamped()
    {
        if (selectedObject != null)
        {
            if (!selectedObject.GetComponent<PostInfo>().stamped)
            {
                selectedObject.GetComponent<PostInfo>().stamped = true;
                selectedObject.GetComponent<PostInfo>().setStampColor(Color.green);
                updatePostInfoDisplay();
            }
        }
    }

    public void updatePostInfoDisplay()
    {
        PostInfo postInfo = selectedObject.GetComponent<PostInfo>();
        if (postInfo != null)
        {
            money.text = postInfo.paidPorto + ",-";
            size.text = postInfo.size.x + "cm Width\n" + postInfo.size.z + "cm Length\n" + postInfo.size.y + "cm Height\n";
            weight.text = postInfo.weight + "g";
            if (postInfo.stamped)
            {
                stamp.text = "Stamped";
                stamp.color = Color.green;
            }
            else
            {
                stamp.text = "Not Stamped";
                stamp.color = Color.red;
            }
        }
    }
    
}
