using UnityEngine;

public class Player : MonoBehaviour
{
    //SavingAndLoadingStarshipElements saving;

    public Bullet bullet;
    public int actualHitPoints;
    public GameObject leftShootPoint;
    public GameObject rightShootPoint;

    private float speed;
    private bool isOnBound = false;


    private void Start()
    {
        actualHitPoints = GameManager.Instance.maxPlayerHitpoints;
        speed = GameManager.Instance.playerSpeed;
        //saving = FindObjectOfType<SavingAndLoadingStarshipElements>();
        //saving.DisplayAllElements();
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
        Instantiate(bullet, leftShootPoint.transform.position, Quaternion.identity);
        Instantiate(bullet, rightShootPoint.transform.position, Quaternion.identity);
    }

    public void TakeDamage(int damage)
    {
        actualHitPoints -= damage;

        if (actualHitPoints <= 0)
        {
            Debug.Log("live lost");
        }
    }
}
