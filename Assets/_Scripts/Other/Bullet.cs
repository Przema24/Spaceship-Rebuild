using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 5;

    private float speed = 8;
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
    }
    

    private void Update()
    {
        if (gameObject.transform.position.y > 15)
        {
            Destroy(this.gameObject, 0.1f);
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
