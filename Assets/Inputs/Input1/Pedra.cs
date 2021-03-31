using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    public float speed;
    private float timeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        timeDestroy = 1.0f;
        Destroy (gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
