using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        if (gameData == null)
        {
            gameData = new GameData();
            CreateNewGameData();
        }

        CreateNewGameData();
    }

    private void CreateNewGameData()
    {
        gameData.lives = 3;
        gameData.playerHitpoints = 100;
        gameData.playerShield = 0;
        gameData.playerAttack = 5;
        gameData.playerSpeed = 3.5f;

        gameData.bulletSpeed = 8;
        gameData.gold = 30;
        gameData.stage = 1;
    }
}
