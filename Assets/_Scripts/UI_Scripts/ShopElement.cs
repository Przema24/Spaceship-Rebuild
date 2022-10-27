using UnityEngine;
using UnityEngine.UI;

public class ShopElement : MonoBehaviour
{
    private GameManager gameManager;
    public int price;
    public bool Buyed { get; private set; }
    private Image image;
    private Button btn;

    private void Awake()
    {
        // to-do: wczytywanie z playerprefs
        Buyed = false;
    }

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        image = gameObject.GetComponent<Image>();
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TryBuy);
    }


    public bool IsBuyed()
    {
        if (Buyed == false)
        {
            return false;
        }
        return true;
    }

    public void TryBuy()
    {
        if (Buyed == true)
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
            Buyed = true;
            Debug.Log("kupujesz");
            ChangeColor();
            gameManager.gameData.playerGold -= price;
        }
    }
    private void ChangeColor()
    {
        image.color = Color.white;
    }
}
