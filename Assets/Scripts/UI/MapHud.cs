using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapHud : MonoBehaviour {

    public Text hud_money, hud_day, hud_season, hud_income;
    private DataIO IO;

    private string money, day, season, income;
    private bool isOpen = false;

	void Start ()
    {
        IO = new DataIO();

        money = day = season = income = "";
        updateHud();
	}

    // Updates Hud in map scene, displaying values;
    public void updateHud()
    {
        string season = "";
        switch(IO.getSeason())
        {
            case 0:
                season = "Summer";
                break;
            case 1:
                season = "Autumn";
                break;
            case 2:
                season = "Winter";
                break;
            case 3:
                season = "Spring";
                break;
        }

        if (hud_money != null)
            hud_money.text = "Money: $" + IO.getMoney().ToString();
        if (hud_day != null)
            hud_day.text = "Day: " + IO.getCurrentDay().ToString();
        if (hud_season != null)
            hud_season.text = "Season: " + season;
        if (hud_income != null)
            hud_income.text = "Day: " + IO.getCurrentDay().ToString();
    }

    // Toggles hud open and closed
    public void toggleHud()
    {
        GetComponent<Animator>().SetBool("isOpen", isOpen);
        isOpen = isOpen ? false : true;
    }
}
