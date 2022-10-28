using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    private bool isFirstGameInSession;

    private Vector3 playerStartPosition = new Vector3(0, -3.35f, 0);
    public static GameManager Instance { get; private set; }

    public bool isGameStart = false;

    public int lives;
    public int maxPlayerHitpoints;
    public int maxPlayerShield;
    public int playerAttack;
    public int playerGold;
    public int stage;
    public int enemyBaseAttack;

    public float playerSpeed;
    public float bulletSpeed;
    public float enemyBulletSpeed;
    
    // not save in PlayerPrefs
    public bool gameStart;

    //3, 100, 0, 5, 3.5f, 8, 80, 1, 5, 6f, SceneManager.GetActiveScene().name == "Game")

    private void Awake()
    {
        gameStart = SceneManager.GetActiveScene().name == "Game";
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            isFirstGameInSession = true;
        }

        if (isFirstGameInSession == true)
        {
            if (PlayerPrefs.HasKey("lives"))
            {
                Load();
            }
            else
            {
                FirstSave();
                Debug.Log("nadpisuje dane");
            }
            //CreateNewGameData();
            isFirstGameInSession = false;
        }
        else
        {
            Load();
        }


        if (gameStart)
        {
            Save();
            SpawnPlayer();
        }
        else
        {
            Save();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    //private void CreateNewGameData()
    //{
    //    gameData = new GameData(3, 100, 0, 5, 3.5f, 8, 80, 1, 5, 6f, SceneManager.GetActiveScene().name == "Game");
    //}

    //private void ReloadGameData()
    //{
    //    gameData = new GameData(this.lives, this.maxPlayerHitpoints, this.maxPlayerShield, this.playerAttack, this.playerSpeed, this.bulletSpeed, this.playerGold, this.stage, this.enemyBaseAttack, this.enemyBulletSpeed, SceneManager.GetActiveScene().name == "Game");
    //}

    private void SpawnPlayer()
    {
        Instantiate(player, playerStartPosition, Quaternion.identity);
    }

    public void PlayerGetGold(int gold)
    {
        playerGold += gold;
    }

    public void FirstSave()
    {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("maxPlayerHitpoints", 100);
        PlayerPrefs.SetInt("maxPlayerShield", 0);
        PlayerPrefs.SetInt("playerAttack", 5);

        PlayerPrefs.SetInt("playerGold", 80);
        PlayerPrefs.SetInt("stage", 1);
        PlayerPrefs.SetInt("enemyBaseAttack", 5);

        PlayerPrefs.SetFloat("playerSpeed", 3.5f);
        PlayerPrefs.SetFloat("bulletSpeed", 8f);
        PlayerPrefs.SetFloat("enemyBulletSpeed", 6);

        PlayerPrefs.Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.SetInt("maxPlayerHitpoints", maxPlayerHitpoints);
        PlayerPrefs.SetInt("maxPlayerShield", maxPlayerShield);
        PlayerPrefs.SetInt("playerAttack", playerAttack);

        PlayerPrefs.SetInt("playerGold", playerGold);
        PlayerPrefs.SetInt("stage", stage);
        PlayerPrefs.SetInt("enemyBaseAttack", enemyBaseAttack);

        PlayerPrefs.SetFloat("playerSpeed", playerSpeed);
        PlayerPrefs.SetFloat("bulletSpeed", bulletSpeed);
        PlayerPrefs.SetFloat("enemyBulletSpeed", enemyBulletSpeed);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        lives = PlayerPrefs.GetInt("lives");
        maxPlayerHitpoints = PlayerPrefs.GetInt("maxPlayerHitpoints");
        maxPlayerShield = PlayerPrefs.GetInt("maxPlayerShield");
        playerAttack = PlayerPrefs.GetInt("playerAttack");

        playerGold = PlayerPrefs.GetInt("playerGold");
        stage = PlayerPrefs.GetInt("stage");
        enemyBaseAttack = PlayerPrefs.GetInt("enemyBaseAttack");

        playerSpeed = PlayerPrefs.GetFloat("playerSpeed");
        bulletSpeed = PlayerPrefs.GetFloat("bulletSpeed");
        enemyBulletSpeed = PlayerPrefs.GetFloat("enemyBulletSpeed");
    }
}
