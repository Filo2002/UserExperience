using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPoints : MonoBehaviour
{

    public Text recordText1;
    public Text recordText2;
    public bool isRecord = true;

    // Start is called before the first frame update
    void Start()
    {
        string recordText = isRecord ? "RECORD " : "";
        string points1 = isRecord ? SETTINGS.GetRecord(true).ToString() : SETTINGS.GetPoints(true).ToString();
        string points2 = isRecord ? SETTINGS.GetRecord(false).ToString() : SETTINGS.GetPoints(false).ToString();

        if (SETTINGS.GetRecord(true) == 0)
                recordText1.text = "";
            else
                recordText1.text = recordText + SETTINGS.GetPlayerName(true) + " : " + points1;

            if (SETTINGS.GetRecord(false) == 0)
                recordText2.text = "";
            else
                recordText2.text = recordText + SETTINGS.GetPlayerName(false) + " : " + points2;
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
