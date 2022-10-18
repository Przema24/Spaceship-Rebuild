using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Base class for enemy

    protected WaveManager waveManager;

    protected int hitpoints;
    protected int damage;
    public int gold;

    protected float speed;

    protected Vector2 moveDirection = new Vector2(0,-1);

    

    private void Update()
    {
        if (gameObject.transform.position.y < -8)
        {
            waveManager.enemiesOnBoard--;
            Death();
        }
    }


    protected void Move()
    {
        gameObject.transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    public virtual void TakeDamage(int damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            
            DropGold(gold);
            waveManager.enemiesOnBoard--;
            Death();
        }
    }

    public virtual void DropGold(int gold)
    {
        GameManager.Instance.gameData.playerGold += gold;
    }

    private void Death()
    {
        Destroy(gameObject);
    }


}
