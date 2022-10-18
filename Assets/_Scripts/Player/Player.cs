using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bullet;
    public int hitPoints; 

    private float speed;
    private bool isOnBound = false;

    private void Start()
    {
        hitPoints = GameManager.Instance.gameData.maxPlayerHitpoints;
        speed = GameManager.Instance.gameData.playerSpeed;
    }

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
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
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
        Instantiate(bullet, GetComponentsInChildren<PlaneElement>()[2].transform.position, Quaternion.identity);
        Instantiate(bullet, GetComponentsInChildren<PlaneElement>()[4].transform.position, Quaternion.identity);
    }

    
}
