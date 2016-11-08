using UnityEngine;
using System.Collections;

public class ScoreHandler : MonoBehaviour {
    private int _amount_Package;
    private int _amount_Large;
    private int _amount_Small;
    private int _amount_Porto;
    private int _amount_Wrong;
    private int _amount_Lost;
    private int _amount_Garbage;
    private int _amount_notStamped;

    private GameObject HUD;

    void Start ()
    {
        amount_Package = amount_Large = amount_Small = amount_Porto  = amount_Wrong = amount_Lost = amount_Garbage = amount_notStamped = 0;
        HUD = GameObject.FindGameObjectWithTag("HUD");
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

    private void updateHUD()
    {
        int correct = amount_Package + amount_Large + amount_Small;
        int wrong = amount_Wrong + amount_Garbage + amount_Lost;
        if (HUD != null)
        {
            HUD.GetComponent<HUDHandler>().setCorrect(correct.ToString());
            HUD.GetComponent<HUDHandler>().setWrong(wrong.ToString());
            HUD.GetComponent<HUDHandler>().setPorto(amount_Porto.ToString());
        }
        
    }

    public int amount_Package { get { return _amount_Package; } set { _amount_Package = value; updateHUD(); } }
    public int amount_Large { get { return _amount_Large; } set { _amount_Large = value; updateHUD(); } }
    public int amount_Small { get { return _amount_Small; } set { _amount_Small = value; updateHUD(); } }
    public int amount_Porto { get { return _amount_Porto; } set { _amount_Porto = value; updateHUD(); } }
    public int amount_Wrong { get { return _amount_Wrong; } set { _amount_Wrong = value; updateHUD(); } }
    public int amount_Lost { get { return _amount_Lost; } set { _amount_Lost = value; updateHUD(); } }
    public int amount_Garbage { get { return _amount_Garbage; } set { _amount_Garbage = value; updateHUD(); } }
    public int amount_notStamped { get { return _amount_notStamped; } set { _amount_notStamped = value; updateHUD(); } }

}
