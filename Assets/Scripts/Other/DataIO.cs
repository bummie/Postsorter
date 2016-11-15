using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataIO
{
    // Settings
    public const string SETTINGS_SOUND_SFX = "settings_sound_sfx",
                        SETTINGS_SOUND_MUSIC = "settings_sound_music",
                        SETTINGS_FIRSTIME = "settigs_firsttime";

    // Playerdata
    public const string PLAYERDATA_POSTOFFICE_NAME = "playerdata_postoffice_name",
                        PLAYERDATA_CURRENTDAY = "playerdata_currentday",
                        PLAYERDATA_MONEY = "playerdata_money",
                        PLAYERDATA_SEASON = "playerdata_season";

    // Districts
    public const string DISTRICT_NAME = "district_name_",
                        DISTRICT_UNLOCKED = "district_unlocked_",
                        DISTRICT_POSTOFFICE_LEVEL = "district_postoffice_level_",
                        DISTRICT_WORKERS = "district_workers_";

    public const int AMOUNT_DISTRICTS = 8;

    public DataIO()
    {
        firstLoad();
    }

    public bool firstLoad()
    {
        bool first = false;

        if (!PlayerPrefs.HasKey(SETTINGS_FIRSTIME))
        {
            firstTimeInitData();
            first = true;
        }

        return first;
    }

    private void firstTimeInitData()
    {
        Debug.Log("Init: DataIO");
        //Settings
        setSFX(true);
        setMusic(true);
        setFirstTime(false);

        //Player
        setOfficeName("Unnamed");
        setCurrentDay(0);
        setSeason(0);
        setMoney(0);

        //Districts
        for (int i = 0; i < AMOUNT_DISTRICTS; i++)
        {
            setDistrictName(i, "Unnamed");
            setPostOfficeLevel(i, 0);
            setAmountWorkers(i, 0);

            if (i == 0)
                setDistrictUnlocked(i, true);
            else
                setDistrictUnlocked(i, false);
        }
    }

    public int[] getUnlockedDistricts()
    {
        List<int> unlockedDistricts = new List<int>();
        //Districts
        for (int i = 0; i < AMOUNT_DISTRICTS; i++)
        {
            if (getDistrictUnlocked(i))
                unlockedDistricts.Add(i);
        }
        return unlockedDistricts.ToArray();
    }

    //
    // Settings
    //

    public void setSFX(bool ison)
    {
        int i = 0;
        if (ison)
            i = 1;
   
        PlayerPrefs.SetInt(SETTINGS_SOUND_SFX, i);
        PlayerPrefs.Save();
    }

    public bool getSFX()
    {
        if (PlayerPrefs.HasKey(SETTINGS_SOUND_SFX))
        {
            bool ison = false;
            if (PlayerPrefs.GetInt(SETTINGS_SOUND_SFX) == 1)
                ison = true;
            return ison; 
        }
        else
            return false;
    }

    public void setMusic(bool ison)
    {
        int i = 0;
        if (ison)
            i = 1;

        PlayerPrefs.SetInt(SETTINGS_SOUND_MUSIC, i);
        PlayerPrefs.Save();
    }

    public bool getMusic()
    {
        if (PlayerPrefs.HasKey(SETTINGS_SOUND_MUSIC))
        {
            bool ison = false;
            if (PlayerPrefs.GetInt(SETTINGS_SOUND_MUSIC) == 1)
                ison = true;
            return ison;
        }
        else
            return false;
    }

    public void setFirstTime(bool first)
    {
        int i = 0;
        if (first)
            i = 1;

        PlayerPrefs.SetInt(SETTINGS_FIRSTIME, i);
        PlayerPrefs.Save();
    }

    public bool getFirstTime()
    {
        if (PlayerPrefs.HasKey(SETTINGS_FIRSTIME))
        {
            bool ison = false;
            if (PlayerPrefs.GetInt(SETTINGS_FIRSTIME) == 1)
                ison = true;
            return ison;
        }
        else
            return false;
    }

    //
    // Playerdata
    //

    public void setOfficeName(string name)
    {
        PlayerPrefs.SetString(PLAYERDATA_POSTOFFICE_NAME, name);
        PlayerPrefs.Save();
    }

    public string getOfficeName()
    {
        string name = "Unnamed";
        if (PlayerPrefs.HasKey(PLAYERDATA_POSTOFFICE_NAME))
        {
            name = PlayerPrefs.GetString(PLAYERDATA_POSTOFFICE_NAME);
        }
        return name;
    }

    public void setCurrentDay(int day)
    {
        PlayerPrefs.SetInt(PLAYERDATA_CURRENTDAY, day);
        PlayerPrefs.Save();
    }

    public int getCurrentDay()
    {
        int day = 0;
        if (PlayerPrefs.HasKey(PLAYERDATA_CURRENTDAY))
        {
            day = PlayerPrefs.GetInt(PLAYERDATA_CURRENTDAY);
        }
        return day;
    }

    public void setSeason(int season)
    {
        PlayerPrefs.SetInt(PLAYERDATA_SEASON, season);
        PlayerPrefs.Save();
    }

    public int getSeason()
    {
        int season = 0;
        if (PlayerPrefs.HasKey(PLAYERDATA_SEASON))
        {
            season = PlayerPrefs.GetInt(PLAYERDATA_SEASON);
        }
        return season;
    }

    public void setMoney(int money)
    {
        PlayerPrefs.SetInt(PLAYERDATA_MONEY, money);
        PlayerPrefs.Save();
    }

    public int getMoney()
    {
        int money = 0;
        if (PlayerPrefs.HasKey(PLAYERDATA_MONEY))
        {
            money = PlayerPrefs.GetInt(PLAYERDATA_MONEY);
        }
        return money;
    }

    //
    // District
    //

    public void setDistrictName(int id, string name)
    {
        PlayerPrefs.SetString(DISTRICT_NAME + id, name);
        PlayerPrefs.Save();
    }

    public string getDistrictName(int id)
    {
        string name = "Unnamed";
        if (PlayerPrefs.HasKey(DISTRICT_NAME + id))
        {
            name = PlayerPrefs.GetString(DISTRICT_NAME + id);
        }
        return name;
    }

    public void setPostOfficeLevel(int id, int level)
    {
        PlayerPrefs.SetInt(DISTRICT_POSTOFFICE_LEVEL + id, level);
        PlayerPrefs.Save();
    }

    public int getPostOfficeLevel(int id)
    {
        int level = 0;
        if (PlayerPrefs.HasKey(DISTRICT_POSTOFFICE_LEVEL + id))
        {
            level = PlayerPrefs.GetInt(DISTRICT_POSTOFFICE_LEVEL + id);
        }
        return level;
    }

    public void setAmountWorkers(int id, int workers)
    {
        PlayerPrefs.SetInt(DISTRICT_WORKERS + id, workers);
        PlayerPrefs.Save();
    }

    public int getMoney(int id)
    {
        int workers = 0;
        if (PlayerPrefs.HasKey(DISTRICT_WORKERS + id))
        {
            workers = PlayerPrefs.GetInt(DISTRICT_WORKERS + id);
        }
        return workers;
    }

    public void setDistrictUnlocked(int id, bool locked)
    {
        int i = 0;
        if (locked)
            i = 1;

        PlayerPrefs.SetInt(DISTRICT_UNLOCKED + id, i);
        PlayerPrefs.Save();
    }

    public bool getDistrictUnlocked(int id)
    {
        if (PlayerPrefs.HasKey(DISTRICT_UNLOCKED + id))
        {
            bool locked = false;
            if (PlayerPrefs.GetInt(DISTRICT_UNLOCKED + id) == 1)
                locked = true;
            return locked;
        }
        else
            return false;
    }
}
