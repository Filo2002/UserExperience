using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStorage : MonoBehaviour
{
    public static float score = 0;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetScore(float x)
    {
        score = x;
        
    }

    public float GetScore()
    {
        return score;
    }
}
