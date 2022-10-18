using Unity.VisualScripting;
using UnityEngine;

public class SmallInsect : Enemy
{
    private void Start()
    {
        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();

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
