using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInfo : MonoBehaviour
{
    static SETTINGS settings = new SETTINGS();
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
                    settings.SetSkin(code);
                    break;
                case "base":
                    settings.SetBase(code);

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
                available = code == settings.GetSkin();
                break;
            case "base":
                available = code == settings.GetBase();
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
