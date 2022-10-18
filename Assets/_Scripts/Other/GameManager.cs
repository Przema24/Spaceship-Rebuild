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
            gameData = new GameData(3, 100, 0, 5, 3.5f, 8, 30 ,1);
            CreateNewGameData();
        }

        CreateNewGameData();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("quit");
            Application.Quit();
        }
    }

    private void CreateNewGameData()
    {
        gameData.lives = 3;
        gameData.maxPlayerHitpoints = 100;
        gameData.maxPlayerShield = 0;
        gameData.playerAttack = 5;
        gameData.playerSpeed = 3.5f;

        gameData.bulletSpeed = 8f;
        gameData.playerGold = 30;
        gameData.stage = 1;
    }
}
