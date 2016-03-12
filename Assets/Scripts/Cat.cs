using UnityEngine;
using System.Collections;

public class Cat : MonoBehaviour
{
    public Direction dir;
    Vector2 movement;
    public float speedMin = 3f;
    public float speedMax = 6f;
    public GameObject explosion;
    float speed;
    void Start()
    {
        Debug.Assert(explosion != null);
        speed = Random.Range(speedMin, speedMax);
    }

    void Die()
    {
        GameController.instance.PlayRandomSound(SoundType.Hiss);
        GameController.instance.AddPoints(PointType.Failcat);
        GameController.instance.ShowMessage("Failcat");
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }

    void Update()
    {
        switch (dir)
        {
            case Direction.Up:
                movement = transform.position + new Vector3(0, 1 * speed * Time.deltaTime, 0);
                break;
            case Direction.Left:
                movement = transform.position + new Vector3(-1 * speed * Time.deltaTime, 0, 0);
                break;
            case Direction.Right:
                movement = transform.position + new Vector3(1 * speed * Time.deltaTime, 0, 0);
                break;
            case Direction.Down:
                movement = transform.position + new Vector3(0, -1 * speed * Time.deltaTime, 0);
                break;
            default:
                Debug.Log("Unknown direction");
                break;
        }
        transform.position = movement;
        switch (dir)
        {
            case Direction.Up:
                if (transform.position.y >= 9.0f) { Die(); }
                break;
            case Direction.Left:
                if (transform.position.x <= -9.0f) { Die(); }
                break;
            case Direction.Right:
                if (transform.position.x >= 9.0f) { Die(); }
                break;
            case Direction.Down:
                if (transform.position.y <= -9.0f) { Die(); }
                break;
            default:
                break;
        }
    }
}
