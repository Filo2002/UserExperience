using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void startGame()
    {

        SceneManager.LoadScene("GameScene");

    }

    public void goToMenu()
    {

        SceneManager.LoadScene("Menu");

    }

    public void goToShop()
    {

        SceneManager.LoadScene("Shop");

    }
}
