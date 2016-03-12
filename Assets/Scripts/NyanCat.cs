using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class NyanCat : MonoBehaviour
{
    public Gradient gradient;
    SpriteRenderer sr;
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float t = Mathf.Repeat(Time.time, 1.0f) / 1.0f;
        sr.color = gradient.Evaluate(t);
    }
}
