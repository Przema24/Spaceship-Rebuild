using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int hitpoints;
    protected int damage;

    protected float speed;

    protected Vector2 moveDirection = new Vector2(0,-1);

    protected void Move()
    {
        gameObject.transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    public virtual void TakeDamage(int damage)
    {
        hitpoints -= damage;

        if (hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
