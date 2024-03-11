using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    public static bool singleplayer = true;
    public static string player1 = "Player 1", player2 = "Player 2";

    public UnityEngine.UI.Toggle toggleSingleplayer;
    public InputField Player1Name, Player2Name;

    private void Start()
    {
        toggleSingleplayer.onValueChanged.AddListener(delegate {
            singleplayer = !singleplayer;
            Player2Name.interactable = !singleplayer;
        });

        Player1Name.onValueChanged.AddListener(delegate {
            if(!string.IsNullOrEmpty(Player1Name.text))
            player1 = Player1Name.text;
        });

        Player2Name.onValueChanged.AddListener(delegate {
            if (!string.IsNullOrEmpty(Player2Name.text))
                player2 = Player2Name.text;
        });
    }

    public void ChangeSingleplayer()
    {
        singleplayer = !singleplayer;
    }

    public string GetPlayer1Name()
    {
        return player1;
    }

    public string GetPlayer2Name()
    {
        return player2;
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
