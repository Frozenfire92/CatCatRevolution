using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject upCat, downCat, leftCat, rightCat;
    void Start()
    {
        Debug.Assert(upCat != null);
        Debug.Assert(downCat != null);
        Debug.Assert(leftCat != null);
        Debug.Assert(rightCat != null);
        StartCoroutine(SpawnCat());
    }

    IEnumerator SpawnCat()
    {
        while (Application.isPlaying)
        {
            switch (Random.Range(0,4))
            {
                case 0:
                    Instantiate(upCat, transform.position, transform.rotation);
                    break;
                case 1:
                    Instantiate(downCat, transform.position, transform.rotation);
                    break;
                case 2:
                    Instantiate(leftCat, transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(rightCat, transform.position, transform.rotation);
                    break;
                default:
                    Debug.Log("OUT OF RANGES!");
                    break;
            }
            yield return new WaitForSeconds(Random.Range(0.1f, 3.0f));
        }
    }
}
