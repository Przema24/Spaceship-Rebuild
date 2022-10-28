using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Class for manage player projectile behaviour

    private int damage;
    private float speed;
    private void Start()
    {
        damage = GameManager.Instance.playerAttack;
        speed = GameManager.Instance.bulletSpeed;
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector2(0, 1) * speed *  Time.deltaTime);
    }
    

    private void Update()
    {
        if (gameObject.transform.position.y > 15)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject != null)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
