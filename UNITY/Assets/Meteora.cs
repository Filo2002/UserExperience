using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class Meteora : MonoBehaviour
{

    public GameObject meteoraOBJ;


    // Start is called before the first frame update
    void Start()
    {
        meteoraOBJ.SetActive(false);
    }

    void Lancia()
    {
        this.GetComponent<Image>().sprite = null;
        this.GetComponent<Image>().color = Color.red;
        meteoraOBJ.SetActive(true);
        Vector3 posOBJ = meteoraOBJ.GetComponent<Transform>().position;
        posOBJ.x = this.GetComponent<RectTransform>().position.x;

        meteoraOBJ.GetComponent<Transform>().SetPositionAndRotation(posOBJ, meteoraOBJ.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F))
        {
            Vector3 pos = this.GetComponent<RectTransform>().position;
            pos.x -= 0.01f; 
            this.GetComponent<RectTransform>().position = pos;

        }

        if (Input.GetKey(KeyCode.G))
        {
            Vector3 pos = this.GetComponent<RectTransform>().position;
            pos.x += 0.01f;
            this.GetComponent<RectTransform>().position = pos;

        }

        if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.G))
        {
            Lancia();
        }

    }
}

