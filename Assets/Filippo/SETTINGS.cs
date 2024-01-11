using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Skin
{
    player0 = 0,
    player1 = 1
}

public enum Base
{
    base0 = 0,
    base1 = 1
}

public enum Background
{
    background0 = 0,
    background1 = 1
}

public class SETTINGS : MonoBehaviour
{
    public static Skin current_skin = Skin.player1;
    public static Base current_base = Base.base1;
    public static Background current_background = Background.background1;
    public static int points = 0, record = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public int GetSkin()
    {
        return (int)current_skin;
    }

    public void SetSkin(int code)
    {
        current_skin = (Skin)code;

    }

    public int GetPoints()
    {
        return points;
    }

    public void SetPoints(int x)
    {
        points = x;

    }

    public int GetRecord()
    {
        return record;
    }

    public void SetRecord(int x)
    {
        record = x;

    }

    public int GetBase()
    {
        return (int)current_base;
    }

    public void SetBase(int code)
    {
        current_base = (Base)code;

    }


}
