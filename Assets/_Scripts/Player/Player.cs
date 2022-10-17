using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bullet;
    public int hitPoints = 100;

    private float speed = 3.5f;
    private bool isOnBound = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }
    }

    private void MoveLeft()
    {
        if (isOnBound) return;
        this.gameObject.transform.Translate(new Vector2(-1,0) * Time.deltaTime * speed);
    }

    private void MoveRight()
    {
        if (isOnBound) return;
        this.gameObject.transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
    }

    private void MoveUp()
    {
        this.gameObject.transform.Translate(new Vector2(0, 1) * Time.deltaTime * speed);
    }

    private void MoveDown()
    {
        this.gameObject.transform.Translate(new Vector2(0, -1) * Time.deltaTime * speed);
    }

    private void Shoot()
    {
        Instantiate<Bullet>(bullet, GetComponentsInChildren<PlaneElement>()[2].transform.position, Quaternion.identity);
        Instantiate<Bullet>(bullet, GetComponentsInChildren<PlaneElement>()[4].transform.position, Quaternion.identity);
    }

    
}
