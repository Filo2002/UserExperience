using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    public Text scoreText;
    private ScoreStorage scoreStorage = new ScoreStorage();

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Punteggio: " + ((int)scoreStorage.GetScore()).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
