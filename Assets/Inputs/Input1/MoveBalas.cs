using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalas : MonoBehaviour
{
    public float vel = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2 (vel * Time.deltaTime,0));
    }
}
