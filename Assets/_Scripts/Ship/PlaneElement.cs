using UnityEngine;

public class PlaneElement : MonoBehaviour
{
    // Class manage modular elements of starship

    public Sprite actualSprite;
    public int actualNumber;
    public string type;

    private SpriteRenderer spriteRenderer;

    private string gameObjectName;

    private void LoadSprites()
    {
        PlayerPrefs.SetInt("tier", actualNumber);
        PlayerPrefs.Save();
        gameObjectName = this.gameObject.name;
        actualSprite = Resources.Load<Sprite>("Starship/" + gameObjectName + "_0" + (actualNumber + 1));
    }

    private void Start()
    {
        actualNumber = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();

        LoadSprites();
        displaySprite();
    }

    public void displaySprite()
    {
        if (actualSprite != null)
        {
            spriteRenderer.sprite = actualSprite;
            Debug.Log("update sprite");
        }
    }

    public void displaySprite(int tier)
    {
        if (actualSprite != null)
        {
            actualNumber = tier;
            actualSprite = Resources.Load<Sprite>("Starship/" + gameObjectName + "_0" + (tier + 1));
            spriteRenderer.sprite = actualSprite;
            Debug.Log("update sprite again");
        }
    }

    //public void updateSprite()
    //{
    //    displaySprite();
    //}
    //
    //public void updateActualNumber(int tier)
    //{
   //     actualSprite = Resources.Load<Sprite>("Starship/" + gameObjectName + "_0" + (tier + 1));
    //    PlayerPrefs.SetInt("tier", tier);
    //    PlayerPrefs.Save();
    //    actualNumber = tier;
    //}
}
