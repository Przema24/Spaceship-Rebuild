using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private int damage;
    private float speed;

    public int multipler;

    private void Start()
    {
        speed = GameManager.Instance.gameData.enemyBulletSpeed;
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
    }


    private void Update()
    {
        if (Mathf.Abs(gameObject.transform.position.y) > 15 || Mathf.Abs(gameObject.transform.position.x) > 15)
        {
            Destroy(this.gameObject);
        }
    }

    private void CalculateDamage()
    {
        damage = GameManager.Instance.gameData.enemyBaseAttack * multipler;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CalculateDamage();
        if (collision.transform.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
