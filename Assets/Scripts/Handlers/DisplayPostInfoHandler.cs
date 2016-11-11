using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPostInfoHandler : MonoBehaviour {

    private GameObject selectedObject;
    private Text money, size, weight, stamp;
    private Button stampButton;

	void Start ()
    {
        money = GameObject.Find("text_money").GetComponent<Text>();
        size = GameObject.Find("text_ruler").GetComponent<Text>();
        weight = GameObject.Find("text_weight").GetComponent<Text>();
        stamp = GameObject.Find("text_stamp").GetComponent<Text>();
        stampButton = GameObject.FindGameObjectWithTag("Stamp_Button").GetComponent<Button>();
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
                if (stampButton != null)
                {
                    ColorBlock cb = stampButton.colors;
                    cb.normalColor = Color.green;
                    stampButton.colors = cb;
                }
                updatePostInfoDisplay();
            }
        }
    }

    public void updatePostInfoDisplay()
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

            money.text = postInfo.paidPorto + ",-";
            size.text = "L: " + length + "\nW: " + width + "\nH: " + height; 
            weight.text = postInfo.weight + "g";
            if (postInfo.stamped)
            {
                stamp.text = "Stamped";
                stamp.color = Color.green;
                if (stampButton != null)
                {
                    ColorBlock cb = stampButton.colors;
                    cb.normalColor = Color.green;
                    stampButton.colors = cb;
                }
            }
            else
            {
                stamp.text = "Not Stamped";
                stamp.color = Color.red;
                if (stampButton != null)
                {
                    ColorBlock cb = stampButton.colors;
                    cb.normalColor = Color.red;
                    stampButton.colors = cb;
                }
            }
        }
    }
    
}
