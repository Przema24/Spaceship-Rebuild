using UnityEngine;
using System.Linq;

public class PlaneElement : MonoBehaviour
{
    // Class manage modular elements of starship

    public Sprite actualSprite;
    public int actualNumber;

    private SpriteRenderer spriteRenderer;

    private string gameObjectName;

    private void LoadSprites()
    {
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

    private void displaySprite()
    {
        if (actualSprite != null)
        {
            spriteRenderer.sprite = actualSprite;
        }
    }
}
