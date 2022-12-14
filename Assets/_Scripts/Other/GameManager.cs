using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    private bool isFirstGameInSession;

    // tiers for plane items used
    public int planeBody;
    public int leftWing;
    public int rightWing;
    public int blasters;



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

    private void Awake()
    {
        gameStart = SceneManager.GetActiveScene().name == "Game";
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            isFirstGameInSession = true;
            planeBody = 0;
            leftWing = 0;
            rightWing = 0;
            blasters = 0;

            // loading all data for next sessions after application close TO-DO
        }

        if (isFirstGameInSession == true)
        {
            if (PlayerPrefs.HasKey("lives"))
            {
                Load();

            }
            else
            {
                FirstLoadData();
            }
            isFirstGameInSession = false;
        }
        else
        {
            Load();
        }
    }

    private void Start()
    {
        if (gameStart)
        {
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            FirstLoadData();
        }
    }


    private void SpawnPlayer()
    {
        Instantiate(player, playerStartPosition, Quaternion.identity);
    }


    public void PlayerGetGold(int gold)
    {
        playerGold += gold;
    }

    public void UpdatePlaneElementTierData(string name, int tier)
    {
        if (name == "body")
        {
            planeBody = tier;
        }
        else if (name == "leftwing")
        {
            leftWing = tier;
        }
        else if (name == "rightwing")
        {
            rightWing = tier;
        }
        else if (name == "blasters")
        {
            blasters = tier;
        }

        Save();
    }

    public void FirstLoadData()
    {
        // on first game

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



        PlayerPrefs.SetInt("planeBody", 0);
        PlayerPrefs.SetInt("leftWing", 0);
        PlayerPrefs.SetInt("rightWing", 0);
        PlayerPrefs.SetInt("blasters",0 );

        PlayerPrefs.Save();

        Load();
    }

    public void Save()
    {
        // save data in playerprefs

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

        PlayerPrefs.SetInt("planeBody", planeBody);
        PlayerPrefs.SetInt("leftWing", leftWing);
        PlayerPrefs.SetInt("rightWing", rightWing);
        PlayerPrefs.SetInt("blasters", blasters);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        // Load last save to gameManager variables

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

        planeBody = PlayerPrefs.GetInt("planeBody");
        leftWing = PlayerPrefs.GetInt("leftWing");
        rightWing = PlayerPrefs.GetInt("rightWing");
        blasters =  PlayerPrefs.GetInt("blasters");
    }
}
