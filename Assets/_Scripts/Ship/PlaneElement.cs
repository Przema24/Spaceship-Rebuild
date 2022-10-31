using UnityEngine;

public class PlaneElement : MonoBehaviour
{
    // Class manage modular elements of starship

    public Sprite actualSprite;
    public int actualNumber;
    public string planeName;

    private SpriteRenderer spriteRenderer;
    public Sprite[] spritesToDisplay;

    private GameManager gameManager;

    // awake for test
    private void Awake()
    {
        //actualNumber = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        LoadMe();
    }

    private void LoadMe()
    {
        int loadingTier;

        if (planeName == "PlanesBody")
        {
            loadingTier = gameManager.planeBody;
        }
        else if (planeName == "LeftWing")
        {
            loadingTier = gameManager.leftWing;
        }
        else if (planeName == "RightWing")
        {
            loadingTier = gameManager.rightWing;
        }
        else  
        {
            loadingTier = gameManager.blasters;
        }

        actualSprite = Resources.Load<Sprite>("Starship/" + planeName + "_0" + (loadingTier + 1));
        spriteRenderer.sprite = actualSprite;
    }


    public void displaySprite(int tier)
    {
        actualNumber = tier;
        
        if (actualSprite != null)
        {
            if (planeName == "Blasters")
            {
                switch (tier)
                {
                    case 0:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "blasters" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 1:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "blasters" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 2:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "blasters" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 3:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "blasters" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 4:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "blasters" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                }
            }
            else if (planeName == "LeftWing")
            {
                switch (tier)
                {
                    case 0:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "leftWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 1:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "leftWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 2:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "leftWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 3:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "leftWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 4:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "leftWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                }
            }
            else if (planeName == "PlanesBody")
            {
                switch (tier)
                {
                    case 0:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "PlanesBody" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 1:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "PlanesBody" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 2:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "PlanesBody" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 3:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "PlanesBody" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 4:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "PlanesBody" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                }
            }
            else if (planeName == "RightWing")
            {
                switch (tier)
                {
                    case 0:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "RightWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 1:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "RightWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 2:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "RightWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 3:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "RightWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                    case 4:
                        actualSprite = Resources.Load<Sprite>("Starship/" + "RightWing" + "_0" + (tier + 1));
                        spriteRenderer.sprite = actualSprite;
                        break;
                }
            }
        }
    }
}
