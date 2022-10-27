using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    public EnemyProjectile projectile;

    protected WaveManager waveManager;
    protected float timer;

    protected int hitpoints;
    protected int damageMultipler;
    public int gold;

    protected float speed;

    protected Vector2 moveDirection = new Vector2(0,-1);

    

    private void Update()
    {
        if (gameObject.transform.position.y < -8)
        {
            BehindScreenDeatch();
        }
    }

    private void BehindScreenDeatch()
    {
        waveManager.enemyList.Remove(gameObject.GetComponent<Enemy>());
        Destroy(gameObject);
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
            Death();
        }
    }

    public virtual void DropGold(int gold)
    {
        GameManager.Instance.PlayerGetGold(gold);
    }

    private void Death()
    {
        DropGold(gold);
        waveManager.enemyList.Remove(gameObject.GetComponent<Enemy>());
        Destroy(gameObject);
    }

    protected virtual void Attack()
    {
        EnemyProjectile enemyProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        enemyProjectile.multipler = damageMultipler;
    }
}
