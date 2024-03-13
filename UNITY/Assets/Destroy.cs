﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;

public class Destroy : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip jump1, jump2;
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    public GameObject terrainPrefab;
    public GameObject myPlat;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Terrain"))
        {

                Destroy(collision.gameObject);
         

        }

        if (collision.gameObject.name.StartsWith("Platform"))
        {
            
            if (Random.Range(1, 7) == 1)
            {
                
                Destroy(collision.gameObject);
                Instantiate(springPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);
                Instantiate(terrainPrefab, new Vector2(Random.Range(-7f, 7f), player.transform.position.y + (14 + Random.Range(-7f, 7f))), Quaternion.identity);

            }
            else
            {
                audioSource.clip = jump1;
                audioSource.Play();
                collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f)));

            }

        }

        else if(collision.gameObject.name.StartsWith("Spring"))
        {
           
            if (Random.Range(1, 7) == 1)
            {

                collision.gameObject.transform.position = new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f)));
                audioSource.clip = jump2;
                audioSource.Play();
            }
            else
            {
               
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-4.5f, 4.5f), player.transform.position.y + (14 + Random.Range(0.2f, 1.0f))), Quaternion.identity);


            }

        }


        // Destroy(collision.gameObject);


        //  myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-5.5f, 5.5f), player.transform.position.y + (14 + Random.Range(0.5f, 0.8f))), Quaternion.identity);
        //  Debug.Log("Created Normal");

        //    if (Random.Range(1, 6) == 1)
        //       {

        //       Instantiate(springPrefab, new Vector2(myPlat.transform.position.x, myPlat.transform.position.y + 0.4f), Quaternion.identity);

        //   }
    }

}