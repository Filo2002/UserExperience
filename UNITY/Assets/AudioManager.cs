using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SETTINGS.audioEnabled)
            this.GetComponent<AudioSource>().enabled = true;
        else
            this.GetComponent<AudioSource>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
