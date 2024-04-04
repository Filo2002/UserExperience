using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHeight : MonoBehaviour
{
    public GameObject camera;
    public GameObject player1;

    public GameObject player2;

    public bool multiplayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(camera.transform.position.x, player1.transform.position.y, camera.transform.position.z);
        camera.transform.SetPositionAndRotation(temp, camera.transform.rotation);

        if(Input.GetKeyDown(KeyCode.K) && multiplayer == false)
        {
            multiplayer = true;
            player2.gameObject.SetActive(true);
            player2.transform.SetPositionAndRotation(player1.transform.position, player1.transform.rotation);
        }

    }
}
