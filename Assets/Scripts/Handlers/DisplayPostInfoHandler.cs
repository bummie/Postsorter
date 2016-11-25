using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPostInfoHandler : MonoBehaviour {

    private GameObject selectedObject;
    private Text money, size, weight, stamp;
    private Image stampButton;
    private AudioSource lyd_stamp;
    private Color green, red;

	void Start ()
    {
        money = GameObject.Find("text_money").GetComponent<Text>();
        size = GameObject.Find("text_ruler").GetComponent<Text>();
        weight = GameObject.Find("text_weight").GetComponent<Text>();
        stamp = GameObject.Find("text_stamp").GetComponent<Text>();
        stampButton = GameObject.FindGameObjectWithTag("Stamp_Button").GetComponent<Image>();
        lyd_stamp = GameObject.FindGameObjectWithTag("Lyd_Stamp").GetComponent<AudioSource>();
        green = new Color(86f, 208f, 86f);
        red = new Color(202f, 86f, 86f);
    }

    public void setSelected(GameObject postObj)
    {
        selectedObject = postObj;
        updatePostInfoDisplay();
    }

    public void setSelectedStamped()
    {
        if (selectedObject != null && selectedObject.tag == "post")
        {
            if (!selectedObject.GetComponent<PostInfo>().stamped)
            {
                selectedObject.GetComponent<PostInfo>().stamped = true;
                selectedObject.GetComponent<PostInfo>().setStampColor(Color.green);
                if (stampButton != null)
                {

                    stampButton.color = green;
                }
                if (lyd_stamp != null)
                    lyd_stamp.Play();
                updatePostInfoDisplay();
            }
        }
    }

    public void updatePostInfoDisplay()
    {
        if (selectedObject.tag == "post")
        {
            PostInfo postInfo = selectedObject.GetComponent<PostInfo>();
            if (postInfo != null)
            {
                float length, width, height;
                Vector3 _size = postInfo.size;
                if (_size.x >= _size.z)
                {
                    length = _size.x;
                    width = _size.z;
                }
                else
                {
                    length = _size.z;
                    width = _size.x;
                }

                height = _size.y;

                money.text = postInfo.paidPorto + "<color=grey>,-</color>";
                size.text = "<color=grey>H:</color> " + height + ", <color=grey>L:</color>  " + length + ", <color=grey>W:</color>  " + width;
                weight.text = postInfo.weight + "<color=grey>g</color>";
                if (postInfo.stamped)
                {
                    stamp.text = "Stamped";
                    stamp.color = green;
                    if (stampButton != null)
                    {
                        stampButton.color = green;
                    }
                }
                else
                {
                    stamp.text = "Not Stamped";
                    stamp.color = red;
                    if (stampButton != null)
                    {
                        stampButton.color = red;
                    }
                }
            }
        }
        else
        {
            money.text = "Garbage";
            size.text = "Unknown";
            weight.text = "Unknown";
            stamp.text = "Can't stamp";
                
            stamp.color = Color.grey;
            if (stampButton != null)
            {
                stampButton.color = Color.grey;
            }
        }
    }
    
}
