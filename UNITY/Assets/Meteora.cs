using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class Meteora : MonoBehaviour
{

    public GameObject meteoraOBJ;

    private float tempPosXMeteora = 0;
    private bool canLancia = true;



    // Start is called before the first frame update
    void Start()
    {
        meteoraOBJ.SetActive(false);
    }

    void Lancia()
    {
        this.GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
        meteoraOBJ.SetActive(true);
        Vector3 posOBJ = meteoraOBJ.GetComponent<Transform>().position;
        posOBJ.x = this.GetComponent<RectTransform>().position.x;
        posOBJ.y = this.GetComponent<RectTransform>().position.y;
        tempPosXMeteora = posOBJ.y;
        meteoraOBJ.GetComponent<Transform>().SetPositionAndRotation(posOBJ, meteoraOBJ.transform.rotation);
        canLancia = false;
        //LanciaMeteora();
    }

    void FineLancia()
    {
        this.GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
        meteoraOBJ.SetActive(false);
        canLancia = true;
        meteoraOBJ.GetComponent<BoxCollider2D>().isTrigger = false;

        //LanciaMeteora();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.F) && SETTINGS.isStarted && this.GetComponent<RectTransform>().position.x > -5f)
        {
            Vector3 pos = this.GetComponent<RectTransform>().position;
            pos.x -= 0.13f; 
            this.GetComponent<RectTransform>().position = pos;

        }

        if (Input.GetKey(KeyCode.G) && SETTINGS.isStarted && this.GetComponent<RectTransform>().position.x < 5f)
        {
            Vector3 pos = this.GetComponent<RectTransform>().position;
            pos.x += 0.13f;
            this.GetComponent<RectTransform>().position = pos;

        }

        if (Input.GetKey(KeyCode.F) && SETTINGS.isStarted && Input.GetKey(KeyCode.G) && canLancia)
        {
            Lancia();
        }

        if(meteoraOBJ.GetComponent<Transform>().position.y < (tempPosXMeteora - 20) && tempPosXMeteora != 0f)
        {
            FineLancia();
        }
    }

}

