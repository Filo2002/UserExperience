using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeight : MonoBehaviour
{
    public GameObject screen1, screen2;

    public GameObject camera;
    public GameObject player1;

    public GameObject detroyer;
    public GameObject destroyer2;

    public GameObject player2;

    public GameObject boost1;

    public GameObject player2canvas1, player2canvas2;



    public bool multiplayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float yHigher = player1.transform.position.y > player2.transform.position.y ? player1.transform.position.y : player2.transform.position.y;
        if(player2.gameObject.active)
        {
            if (player1.transform.position.y > player2.transform.position.y)
            {
                detroyer.GetComponent<BoxCollider2D>().isTrigger = true;
                destroyer2.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else
            {
                destroyer2.GetComponent<BoxCollider2D>().isTrigger = true;
                detroyer.GetComponent<BoxCollider2D>().isTrigger = false;
            }
        }
        


        Vector3 temp = new Vector3(camera.transform.position.x, yHigher, camera.transform.position.z);
        camera.transform.SetPositionAndRotation(temp, camera.transform.rotation);



        if ((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G)) && multiplayer == false)
        {
            multiplayer = true;
            player2.gameObject.SetActive(true);
            screen1.gameObject.SetActive(true);
            screen2.gameObject.SetActive(true);

            player2canvas1.SetActive(true);
            player2canvas2.SetActive(true);

            Vector3 currentPosition = boost1.GetComponent<RectTransform>().localPosition;
            currentPosition.x = -630;
            boost1.GetComponent<RectTransform>().localPosition = currentPosition;


            Vector3 temp2 = new Vector3(camera.transform.position.x, camera.transform.position.y, 2);
            camera.transform.SetPositionAndRotation(temp2, camera.transform.rotation);
            player2.transform.SetPositionAndRotation(player1.transform.position, player1.transform.rotation);
        }

    }
}
