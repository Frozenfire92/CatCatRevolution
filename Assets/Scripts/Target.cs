using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public Direction direction;
    float distance;
    public GameObject explosion;

    void Start()
    {
        Debug.Assert(explosion != null);
    }
    void CheckDistance(float distance)
    {
        if (distance >= 1.6)
        {
            Debug.Log("Too far");
            GameController.instance.PlayRandomSound(SoundType.Hiss);
            GameController.instance.AddPoints(PointType.Failcat);
            GameController.instance.ShowMessage("Failcat");
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
        else if (distance >= 1.2)
        {
            Debug.Log("Getting closer");
            GameController.instance.PlayRandomSound(SoundType.Hiss);
            GameController.instance.AddPoints(PointType.Meh);
            GameController.instance.ShowMessage("Meh");
            Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        }
        else if (distance >= 0.8)
        {
            Debug.Log("Not bad!");
            GameController.instance.PlayRandomSound(SoundType.Meow);
            GameController.instance.AddPoints(PointType.Good);
            GameController.instance.ShowMessage("Good");
        }
        else if (distance >= 0.4)
        {
            Debug.Log("You Rock!");
            GameController.instance.PlayRandomSound(SoundType.Meow);
            GameController.instance.AddPoints(PointType.Awesome);
            GameController.instance.ShowMessage("Awesome!");
        }
        else if (distance >= 0.1f)
        {
            Debug.Log("SUCH MEOW!");
            GameController.instance.PlayRandomSound(SoundType.Purr);
            GameController.instance.PlayRandomSound(SoundType.Meow);
            GameController.instance.AddPoints(PointType.Purrfect);
            GameController.instance.ShowMessage("Purrrrfffeeeccccctt");
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        Cat cat = col.GetComponent<Cat>();
        distance = (transform.position - col.transform.position).magnitude;
        //Debug.Log("Distance " + distance);
        switch (direction)
        {
            case Direction.Up:
                if (Input.GetButtonDown("Up")) { CheckDistance(distance); Destroy(col.gameObject); }
                break;
            case Direction.Left:
                if (Input.GetButtonDown("Left")) { CheckDistance(distance); Destroy(col.gameObject); }
                break;
            case Direction.Right:
                if (Input.GetButtonDown("Right")) { CheckDistance(distance); Destroy(col.gameObject); }
                break;
            case Direction.Down:
                if (Input.GetButtonDown("Down")) { CheckDistance(distance); Destroy(col.gameObject); }
                break;
            default:
                break;
        }
    }
}
