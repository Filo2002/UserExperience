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
        source.clip = death;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
