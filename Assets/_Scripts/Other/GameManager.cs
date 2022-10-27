using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameData gameData;
    public Player player;
    private bool isFirstGame;

    private Vector3 playerStartPosition = new Vector3(0, -3.35f, 0);
    public static GameManager Instance { get; private set; }

    public bool isGameStart = false;

    public int lives = 3;
    public int maxPlayerHitpoints = 100;
    public int maxPlayerShield = 0;
    public int playerAttack = 5;
    public float playerSpeed = 3.5f;

    public float bulletSpeed = 8;
    public int playerGold = 80;
    public int stage = 1;

    public int enemyBaseAttack = 5;
    public float enemyBulletSpeed = 6;

    public bool gameStart;

    //3, 100, 0, 5, 3.5f, 8, 80, 1, 5, 6f, SceneManager.GetActiveScene().name == "Game")

    private void Awake()
    {
        gameStart = SceneManager.GetActiveScene().name == "Game";
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            isFirstGame = true;
        }
        else
        {
            
        }

        if (isFirstGame == true)
        {
            CreateNewGameData();
            isFirstGame = false;
            Debug.Log("Pierwsza gra");
        }
        else
        {
            ReloadGameData();
            Debug.Log("Kolejna gra");
        }

        isGameStart = gameData.gameStart;

        if (isGameStart)
        {
            SpawnPlayer();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void CreateNewGameData()
    {
        gameData = new GameData(3, 100, 0, 5, 3.5f, 8, 80, 1, 5, 6f, SceneManager.GetActiveScene().name == "Game");
    }

    private void ReloadGameData()
    {
        gameData = new GameData(this.lives, this.maxPlayerHitpoints, this.maxPlayerShield, this.playerAttack, this.playerSpeed, this.bulletSpeed, this.playerGold, this.stage, this.enemyBaseAttack, this.enemyBulletSpeed, SceneManager.GetActiveScene().name == "Game");
    }

    private void SpawnPlayer()
    {
        Instantiate(player, playerStartPosition, Quaternion.identity);
    }

    public void PlayerGetGold(int gold)
    {
        playerGold += gold;
    }
}
