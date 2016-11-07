using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {
    public int amount_Package{ get; set; }
    public int amount_Large{get; set;}
    public int amount_Small { get; set; }
    public int amount_Porto { get; set; }
    public int amount_Wrong { get; set; }
    public int amount_Lost { get; set; }
    public int amount_Garbage { get; set; }
    public int amount_notStamped { get; set; }

    void Start ()
    {
        amount_Package = amount_Large = amount_Small = amount_Porto  = amount_Wrong = amount_Lost = amount_Garbage = amount_notStamped = 0;
	}

    public void printScore()
    {
        Debug.Log("Pakker: " + amount_Package +"\n");
        Debug.Log("Store: " + amount_Large + "\n");
        Debug.Log("Små: " + amount_Small + "\n");
        Debug.Log("Porto: " + amount_Porto + "\n");
        Debug.Log("Feilsortert: " + amount_Wrong + "\n");
        Debug.Log("Mistet: " + amount_Lost + "\n");
        Debug.Log("Søppel: " + amount_Garbage + "\n");
        Debug.Log("Not Stamped: " + amount_notStamped + "\n");

    }

}
