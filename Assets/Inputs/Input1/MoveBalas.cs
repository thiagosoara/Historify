using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalas : MonoBehaviour
{
    public float forca = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2 (forca * Time.deltaTime,0));
        transform.Translate(Vector2.right * forca * Time.deltaTime);
       
        
    }
}
