using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPoints : MonoBehaviour
{

    public Text text;
    public Text recordText;
    public int isRecord = 0;
    private SETTINGS settings;

    // Start is called before the first frame update
    void Start()
    {
        settings = new SETTINGS();
        if(isRecord == 0)
            text.text = settings.GetPoints().ToString();
        else
            recordText.text = "RECORD: " + settings.GetRecord().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
