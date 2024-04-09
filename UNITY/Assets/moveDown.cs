using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveDown : MonoBehaviour
{
    public Transform player;
    float posPlayerY;
    // Start is called before the first frame update
    void Start()
    {
        posPlayerY = player.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.GetComponent<Transform>().position;
        pos.y = (player.position.y - posPlayerY) / 10 + (pos.y - 0.010f);
        this.GetComponent<Transform>().SetPositionAndRotation(pos, this.GetComponent<Transform>().rotation);
        posPlayerY = player.position.y;

    }
}
