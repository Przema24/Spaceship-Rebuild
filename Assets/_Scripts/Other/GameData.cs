public class GameData 
{

    public int lives;
    public int maxPlayerHitpoints;
    public int maxPlayerShield;
    public int playerAttack;
    public float playerSpeed;

    public float bulletSpeed;
    public int playerGold;
    public int stage;

    public GameData(int lives, int maxPlayerHitpoints, int maxPlayerShield, int playerAttack, float playerSpeed, float bulletSpeed, int playerGold, int stage)
    {
        this.lives = lives;
        this.maxPlayerHitpoints = maxPlayerHitpoints;
        this.maxPlayerShield = maxPlayerShield;
        this.playerAttack = playerAttack;
        this.playerSpeed = playerSpeed;

        this.bulletSpeed = bulletSpeed;
        this.playerGold = playerGold;
        this.stage = stage;
    }
}
