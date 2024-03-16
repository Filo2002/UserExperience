using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInfo : MonoBehaviour
{
    public int code;
    public string shopType;

    public Button buttonBuy;
    public Text text_buttonBuy;

    private void Start()
    {
        buttonBuy.onClick.AddListener(() =>
        {
            switch(shopType)
            {
                case "skin":
                    SETTINGS.current_skin = (Skin)code;
                    break;
                case "base":
                    SETTINGS.current_base = (Base)code;

                    break;
            }

        });
    }

    // Start is called before the first frame update
    void Update()
    {
        bool available = false;

        switch (shopType)
        {
            case "skin":
                available = code == (int)SETTINGS.current_skin;
                break;
            case "base":
                available = code == (int)SETTINGS.current_base;
                break;

        }

        if (available)
        {
            text_buttonBuy.text = "SELEZIONATO";

        }
        else
        {
            text_buttonBuy.text = "DISPONIBILE";

        }
    }
}
