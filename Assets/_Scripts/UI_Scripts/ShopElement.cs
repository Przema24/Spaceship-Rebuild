using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;

public class ShopElement : MonoBehaviour
{
    private GameManager gameManager;
    public int tier;
    public string type;
    public int price;
    public bool Bought { get; private set; }
    private Image image;
    private Button btn;
    private TMP_Text text;

    public PlaneElement[] planeElement;
   
    private void Awake()
    {
        // to-do: wczytywanie z playerprefs
        Bought = false;

    }

    private void Start()
    {
        text = gameObject.GetComponentInChildren<TMP_Text>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        image = gameObject.GetComponent<Image>();
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TryBuy);

        UpdatePriceText();
    }

    private void UpdatePriceText()
    {
        if (Bought != true)
        {
            text.text = price.ToString();
            text.color = Color.white;
        }
        else
        {
            text.text = "Bought";
        }
    }


    public bool IsBought()
    {
        if (Bought == false)
        {
            return false;
        }
        return true;
    }

    public void TryBuy()
    {
        if (Bought == true)
        {
            SaveElementTierInUse();
            planeElement[GetPlaneElementPosition(this.gameObject.GetComponent<ShopElement>().type)].displaySprite(tier);
            return;
        }

        if (gameManager.playerGold < price)
        {
            return;
        }
        else
        {
            Bought = true;
            ChangeColor();
            gameManager.playerGold -= price;
            UpdatePriceText();
            SaveElementTierInUse();
            planeElement[GetPlaneElementPosition(this.gameObject.GetComponent<ShopElement>().type)].displaySprite(tier);
        }
    }

    private int GetPlaneElementPosition(string name)
    {
        int index;
        if (name == "body")
        {
            index = 0;
        }
        else if (name == "leftwing")
        {
            index = 1;
        }
        else if (name == "rightwing")
        {
            index = 2;
        }
        else
        {
            index = 3;
        }
        return index;
    }
    private void ChangeColor()
    {
        image.color = Color.white;
    }

    private void SaveElementTierInUse()
    {
        int index;
        if (planeElement[GetPlaneElementPosition(this.gameObject.GetComponent<ShopElement>().type)].name == "body")
        {
            index = 0;
        }
        else if (planeElement[GetPlaneElementPosition(this.gameObject.GetComponent<ShopElement>().type)].name == "leftWing")
        {
            index = 1;
        }
        else if (planeElement[GetPlaneElementPosition(this.gameObject.GetComponent<ShopElement>().type)].name == "rightWing")
        {
            index = 2;
        }
        else
        {
            index = 3;
        }

        switch (index)
        {
            case 0:
                PlayerPrefs.SetInt("bodyTier", tier);
                PlayerPrefs.Save();
                break;
            case 1:
                PlayerPrefs.SetInt("leftWingTier", tier);
                PlayerPrefs.Save();
                break;
            case 2:
                PlayerPrefs.SetInt("rightWingTier", tier);
                PlayerPrefs.Save();
                break;
            case 3:
                PlayerPrefs.SetInt("blastersTier", tier);
                PlayerPrefs.Save();
                break;
            default: Debug.Log("wyjatek");
                break;
        }
    }
}
