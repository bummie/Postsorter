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
    private int _amount_Stamped;

    // Money gain score
    private int money_correct_small = 5;
    private int money_correct_large = 7;
    private int money_correct_package = 10;
    private int money_correct_porto = 30;
    private int money_correct_stamped = 5;

    private int money_wrong_post = -5;
    private int money_wrong_lost = -10;
    private int money_wrong_stamped = -3;
    private int money_wrong_garbage = -3;

    private GameObject HUD;

    void Start ()
    {
        amount_Package = amount_Large = amount_Small = amount_Porto  = amount_Wrong = amount_Lost = amount_Garbage = amount_notStamped = amount_Stamped = 0;
        HUD = GameObject.FindGameObjectWithTag("HUD");
	}

    public int calculateGainedMoney()
    {
        int moneyGained = 0;

        moneyGained += money_correct_small * amount_Small;
        moneyGained += money_correct_large * amount_Large;
        moneyGained += money_correct_package * amount_Package;
        moneyGained += money_correct_porto * amount_Porto;
        moneyGained += money_correct_stamped * amount_Stamped;
        moneyGained += money_wrong_post * amount_Wrong;
        moneyGained += money_wrong_lost * amount_Lost;
        moneyGained += money_wrong_stamped * amount_notStamped;
        moneyGained += money_wrong_garbage * amount_Garbage;

        if (moneyGained < 0)
            moneyGained = 0;
        return moneyGained;
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
        Debug.Log("Not Stamped: " + amount_Stamped + "\n");
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

    public void resetScore()
    {
        amount_Small = 0;
        amount_Large = 0;
        amount_Package = 0;
        amount_Porto = 0;
        amount_Wrong = 0;
        amount_Lost = 0;
        amount_Garbage = 0;
        amount_notStamped = 0;
        amount_Stamped = 0;
    }

    public int amount_Package { get { return _amount_Package; } set { _amount_Package = value; updateHUD(); } }
    public int amount_Large { get { return _amount_Large; } set { _amount_Large = value; updateHUD(); } }
    public int amount_Small { get { return _amount_Small; } set { _amount_Small = value; updateHUD(); } }
    public int amount_Porto { get { return _amount_Porto; } set { _amount_Porto = value; updateHUD(); } }
    public int amount_Wrong { get { return _amount_Wrong; } set { _amount_Wrong = value; updateHUD(); } }
    public int amount_Lost { get { return _amount_Lost; } set { _amount_Lost = value; updateHUD(); } }
    public int amount_Garbage { get { return _amount_Garbage; } set { _amount_Garbage = value; updateHUD(); } }
    public int amount_notStamped { get { return _amount_notStamped; } set { _amount_notStamped = value; updateHUD(); } }
    public int amount_Stamped { get { return _amount_Stamped; } set { _amount_Stamped = value; updateHUD(); } }


}
