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


    public PlaneElement[] planeElements;

   

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
                FirstLoadData();
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


        if (gameStart)
        {

        }
        else
        {
            
            Save();
        }
    }

    private void Start()
    {
        if (gameStart)
        {
            SpawnPlayer();
            DisplayAllElements();
        }
        else
        {
            DisplayAllElements();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
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

    public void FirstLoadData()
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


        // plane elements
        PlayerPrefs.SetInt("planeBody", 0);
        PlayerPrefs.SetInt("leftWing", 0);
        PlayerPrefs.SetInt("rightWing", 0);
        PlayerPrefs.SetInt("blasters",0 );

        PlayerPrefs.Save();

        Load();
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

        PlayerPrefs.SetInt("planeBody", planeBody);
        PlayerPrefs.SetInt("leftWing", leftWing);
        PlayerPrefs.SetInt("rightWing", rightWing);
        PlayerPrefs.SetInt("blasters", blasters);

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

        planeBody = PlayerPrefs.GetInt("planeBody");
        leftWing = PlayerPrefs.GetInt("leftWing");
        rightWing = PlayerPrefs.GetInt("rightWingr");
        blasters =  PlayerPrefs.GetInt("blasters");
    }


    // TEST

    private void DisplayAllElements()
    {
        string[] elementTypes = new string[4];
        elementTypes[0] = "PlaneBody";
        elementTypes[1] = "Blasters";
        elementTypes[2] = "LeftWing";
        elementTypes[3] = "RightWing";


        foreach (string name in elementTypes)
        {
            foreach (PlaneElement p in planeElements)
            {
                //Debug.Log(e.type + " " + p.type);
                if (name == p.planeName)
                {
                    
                }
            }
        }
    }

    public void UpdateElementTier(ShopElement shopElement)
    {
        /*
        string t = shopElement.type;

        switch (t)
        {
            case "body":
                {
                    shopElement.tier = shopElement.tier;
                }
                break;
            case "leftWing":
                {
                    leftwing.tier = shopElement.tier;
                }
                break;
            case "rightWing":
                {
                    rightwing.tier = shopElement.tier;
                }
                break;
            case "blasters":
                {
                    blasters.tier = shopElement.tier;
                }
                break;
        }  */
    }



}
