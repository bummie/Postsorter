using UnityEngine;
using System.Collections;

public class DistrictSelector : MonoBehaviour {

    private int selectedDistrict = -1;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 600.0f))
            {
                if (hit.transform.tag.Equals("District"))
                {
                    string[] districtName = hit.transform.name.Split('_');
                    Debug.Log("Selected district: " + districtName[1]);
                    selectedDistrict = int.Parse(districtName[1]);
                }
            }
        }
    }
}
