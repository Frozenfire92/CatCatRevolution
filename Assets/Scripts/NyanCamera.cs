using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NyanCamera : MonoBehaviour
{
    Camera cam;
    public Gradient gradient;
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    void Update()
    {
        float t = Mathf.Repeat(Time.time, 1.0f) / 1.0f;
        cam.backgroundColor = gradient.Evaluate(t);
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
