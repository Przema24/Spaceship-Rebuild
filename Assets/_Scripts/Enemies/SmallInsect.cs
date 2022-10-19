using Unity.VisualScripting;
using UnityEngine;

public class SmallInsect : Enemy
{
    public EnemyProjectile projectile;

    private float timer;
    private void Start()
    {
        timer = 1.8f;

        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();

        hitpoints = 20;
        damageMultipler = 1;
        speed = 2f;
        gold = 2;
    }

    private void FixedUpdate()
    {
        Move();

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            
            Attack();
            timer = 1.8f;

        }
    }

    protected void Attack()
    {
        EnemyProjectile enemyProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        enemyProjectile.multipler = damageMultipler;
    }
}
