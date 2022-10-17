using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Base class for enemy

    public delegate void Death(Enemy enemy);
    public static event Death OnDeath;

    protected WaveManager waveManager;

    protected int hitpoints;
    protected int damage;

    protected float speed;

    protected Vector2 moveDirection = new Vector2(0,-1);

    private void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -8)
        {
            if (OnDeath != null)
            {
                OnDeath(this.gameObject.GetComponent<Enemy>());
            }
            Destroy(this.gameObject);
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
            if (OnDeath != null)
            {
                OnDeath(this.gameObject.GetComponent<Enemy>());
            }
            Destroy(gameObject);
        }
    }

}
