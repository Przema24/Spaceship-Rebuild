using UnityEngine;

public class SmallInsect : Enemy
{
    private void Start()
    {
        hitpoints = 20;
        damage = 5;
        speed = 2f;
        gold = 2;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
