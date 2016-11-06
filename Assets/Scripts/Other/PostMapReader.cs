using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class PostMapReader
{

    string mapPath = "Maps/Test/map";
    JSONNode mData;

    public PostMapReader()
    {
        TextAsset mapData = Resources.Load<TextAsset>(mapPath);
        mData = JSON.Parse(mapData.text);
    }

    //
    // Returnerer alle postypene for en dag i ett destrikt
    //
    public string[] returnPost(int dag, int district)
    {
        List<string> amount = new List<string>();

        foreach (JSONNode type in mData[dag.ToString()]["district_" + district.ToString()].AsArray)
        {
            amount.Add(type["type"]);
        }
        return amount.ToArray();
    }

    //
    // Setter postobjektets verdier fra JSONfilen
    //
    public void setPostValues(GameObject post, int dag, int district, int index)
    {
        if (post.tag.Equals("post"))
        {
            Vector3 size = new Vector3(mData[dag.ToString()]["district_" + district.ToString()][index]["size"][0].AsFloat, mData[dag.ToString()]["district_" + district.ToString()][index]["size"][1].AsFloat, mData[dag.ToString()]["district_" + district.ToString()][index]["size"][2].AsFloat);
            string type = mData[dag.ToString()]["district_" + district.ToString()][index]["type"];

            if (type.Equals("pakke"))
            {
                Vector3 newSize = size * 0.046f;
                post.transform.localScale = newSize;
            }

            post.GetComponent<PostInfo>().size = size;
            post.GetComponent<PostInfo>().weight = mData[dag.ToString()]["district_" + district.ToString()][index]["weight"].AsFloat;
            post.GetComponent<PostInfo>().paidPorto = mData[dag.ToString()]["district_" + district.ToString()][index]["paid"].AsFloat;
            post.GetComponent<PostInfo>().stamped = mData[dag.ToString()]["district_" + district.ToString()][index]["stamped"].AsBool;
        }
    }
}
