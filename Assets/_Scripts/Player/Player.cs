using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    // Script manage player ship behaviour

    public Bullet bullet;
    public int actualHitPoints; 

    private float speed;
    private bool isOnBound = false;

    //private float tiltSmooth;

    private void Start()
    {
        //tiltSmooth = 5f;
        actualHitPoints = GameManager.Instance.gameData.maxPlayerHitpoints;
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
            //TiltLeft();
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
            //TiltLeft();
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

    //private void TiltLeft()
    //{
    //    Vector3 targetRotation = new Vector3(transform.rotation.x, -0.5f, transform.rotation.z);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(targetRotation.x, targetRotation.y, targetRotation.z, 1), Time.deltaTime * tiltSmooth);
    //}

    //private void TiltRight()
    //{
    //    Vector3 targetRotation = new Vector3(transform.rotation.x, 0.5f, transform.rotation.z);
    //    transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(targetRotation.x, targetRotation.y, targetRotation.z, 1), Time.deltaTime * tiltSmooth);
    //}

    public void TakeDamage(int damage)
    {
        actualHitPoints -= damage;

        if (actualHitPoints <= 0)
        {
            Debug.Log("live lost");
        }
    }
}
