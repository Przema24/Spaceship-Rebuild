using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopElement : MonoBehaviour
{
    private GameManager gameManager;
    public int price;
    public bool Bought { get; private set; }
    private Image image;
    private Button btn;
    private TMP_Text text;
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
            Debug.Log("kupiony juz");
            return;
        }

        if (gameManager.gameData.playerGold < price)
        {
            Debug.Log("nie masz kasy");
            return;
        }
        else
        {
            Bought = true;
            Debug.Log("kupujesz");
            ChangeColor();
            gameManager.gameData.playerGold -= price;
            UpdatePriceText();
        }
    }
    private void ChangeColor()
    {
        image.color = Color.white;
    }
}
