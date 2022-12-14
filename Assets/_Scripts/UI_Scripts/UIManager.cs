using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Button nextLevelBtn;
    private TMP_Text nextLevelBtnText;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        nextLevelBtnText = nextLevelBtn.GetComponentInChildren<TMP_Text>();
        nextLevelBtnText.text = $"Next stage: {gameManager.stage.ToString()}";
        nextLevelBtn.onClick.AddListener(NextWave);
    }

    private void NextWave()
    {
        gameManager.Save();
        SceneManager.LoadScene("Game");
    }
}
