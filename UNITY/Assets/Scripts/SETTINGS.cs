using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
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
    public static int points1 = 0, points2 = 0, record1 = 0, record2 = 0;
    public static bool singleplayer = true;
    public static string player1 = "", player2 = "";
    public static bool isFirstPlayer = true;
    public static bool audioEnabled = true;

    public GameObject audio1, audio2;

    public UnityEngine.UI.Toggle toggleSingleplayer;
    public InputField Player1Name, Player2Name;

    private void Start()
    {
        toggleSingleplayer.isOn = singleplayer;
        Player1Name.text = player1;
        Player2Name.text = player2;

        audio1.SetActive(audioEnabled);
        audio2.SetActive(!audioEnabled);


        toggleSingleplayer.onValueChanged.AddListener(delegate {
            singleplayer = !singleplayer;
            Player2Name.interactable = !singleplayer;
            if (singleplayer)
            {
                Player2Name.text = "";
                player2 = "";
                record2 = 0;
            }
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


    public static string GetPlayerName(bool isFirstPlayer)
    {
        if (isFirstPlayer)
            return string.IsNullOrEmpty(player1) ? "Player 1" : player1;
        else
            return string.IsNullOrEmpty(player2) ? "Player 2" : player2;
    }


    public static int GetRecord(bool isFirstPlayer)
    {
        if (isFirstPlayer)
            return record1;
        else
            return record2;
    }

    public static int GetPoints(bool isFirstPlayer)
    {
        if (isFirstPlayer)
            return points1;
        else
            return points2;
    }

    public static void SetPoints(bool isFirstPlayer, int x)
    {
        if (isFirstPlayer)
            points1 = x;
        else
            points2 = x;
    }

    public static void SetRecord(bool isFirstPlayer, int x)
    {
        if (isFirstPlayer)
            record1 = x;
        else
            record2 = x;
    }

    public static void DisableAudio()
    {
        audioEnabled = false;
    }

    public static void EnableAudio()
    {
        audioEnabled = true;
    }

}
