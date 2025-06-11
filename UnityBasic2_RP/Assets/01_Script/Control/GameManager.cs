using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : SingletonBehabiour<GameManager>
{
     public static PlayerData PData;

    protected override void Awake()
    {
        base.Awake();

        Initialize();
    }

    

    void Initialize()
    {
        bool isFirst = !LoadData();

        Open();

        if(isFirst)
        {
            
        }
    }

    void Open()
    {

    }

    public void SaveData()
    {
        string jsonString = JsonUtility.ToJson(PData);
        PlayerPrefs.SetString("PData", jsonString);
    }

    public bool LoadData()
    {
        if(PlayerPrefs.HasKey("PData"))
        {
            string jsonString = PlayerPrefs.GetString("PData");
            PData = JsonUtility.FromJson<PlayerData>(jsonString);
            return true;
        }
        else
        {
            UnityEngine.Debug.Log("<color=red>Create New Data</color>");
            PData = new PlayerData();
            SaveData();
            return false;
        }
    }
}
