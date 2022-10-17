using UnityEngine;

public class SmallInsect : Enemy
{
    private void Start()
    {
        hitpoints = 20;
        damage = 5;
        speed = 2f;

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -8)
        {
            Destroy(this.gameObject);
        }
    }
}
