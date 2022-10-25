using UnityEngine;

public class BigInsect : Enemy
{
    private void Start()
    {
        timer = 1.2f;

        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();

        hitpoints = 35;
        damageMultipler = 2;
        speed = 1.5f;
        gold = 5;
    }

    private void FixedUpdate()
    {
        Move();

        timer -= Time.deltaTime;

        if (timer <= 0)
        {

            Attack();
            timer = 1.2f;

        }
    }

    protected override void Attack()
    {
        EnemyProjectile enemyProjectile1 = Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(0, 0,-30));
        EnemyProjectile enemyProjectile2 = Instantiate(projectile, gameObject.transform.position, Quaternion.Euler(0, 0, 30));
        enemyProjectile1.multipler = damageMultipler;
        enemyProjectile2.multipler = damageMultipler;
    }
}
