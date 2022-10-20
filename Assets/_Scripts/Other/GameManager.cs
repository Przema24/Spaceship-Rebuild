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
            CreateNewGameData();
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
        gameData = new GameData(3, 100, 0, 5, 3.5f, 8, 30, 1, 5, 6f);
    }
}
