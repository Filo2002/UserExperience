using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInish : MonoBehaviour
{
    public AudioSource source;
    public AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        SETTINGS.isStarted = false;
        source.clip = death;
        SETTINGS.isFirstPlayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
