using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPoints : MonoBehaviour
{

    public Text recordText1;
    public Text recordText2;

    // Start is called before the first frame update
    void Start()
    {
        if (SETTINGS.GetRecord(true) == 0)
            recordText1.text = "";
        else
            recordText1.text = "RECORD " + SETTINGS.GetPlayerName(true) + " : " + SETTINGS.GetRecord(true).ToString();

        if (SETTINGS.GetRecord(false) == 0)
            recordText2.text = "";
        else
            recordText2.text = "RECORD " + SETTINGS.GetPlayerName(false) + " : " + SETTINGS.GetRecord(false).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
