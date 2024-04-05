using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeight : MonoBehaviour
{
    public GameObject camera;
    public GameObject player1;

    public GameObject detroyer;
    public GameObject destroyer2;

    public GameObject player2;

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

        if(Input.GetKeyDown(KeyCode.K) && multiplayer == false)
        {
            multiplayer = true;
            player2.gameObject.SetActive(true);
            player2.transform.SetPositionAndRotation(player1.transform.position, player1.transform.rotation);
        }

    }
}
