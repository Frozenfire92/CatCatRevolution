using UnityEngine;
using System.Collections;

public class DestroyInSeconds : MonoBehaviour
{
    public float delay = 3f;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    // Update is called once per frame
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
