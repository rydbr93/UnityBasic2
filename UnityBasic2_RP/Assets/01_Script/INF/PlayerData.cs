using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        Option = new PlayerOption();
    }

    public PlayerOption Option;
}

public class PlayerOption
{
    public PlayerOption()
    {
        BGMVol = 1;
        SFXVol = 1;
    }

    public float BGMVol;
    public float SFXVol;
}