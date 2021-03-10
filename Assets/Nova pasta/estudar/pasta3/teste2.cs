using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste2 : MonoBehaviour
{
    private float vel=2.5f;
    //public Renderer quad;

    // Start is called before the first frame update
    public float forca = 2.5f;
    public Rigidbody2D policia;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.Translate (new Vector3(-0.1f,0,0));
       //transform.Rotate(new Vector3(0,0,0.5f));
      // transform.localScale +=new Vector3 (0.1f,0.1f,0);
      //Vector2 offset = new Vector2(vel* Time.deltaTime,0);
      //quad.material.mainTextureOffset += offset;
      /*
      //esquerda
      if(Input.GetKey(KeyCode.RightArrow)){
        transform.Translate(new Vector3 (vel * Time.deltaTime,0,0));
      }
      //direita
      if(Input.GetKey(KeyCode.LeftArrow)){
        transform.Translate(new Vector3 (-vel * Time.deltaTime,0,0));
      }
      //para cima
      if(Input.GetKey(KeyCode.UpArrow)){
        transform.Translate(new Vector3 (0,vel * Time.deltaTime,0));
      }
      //para baixo
      if(Input.GetKey(KeyCode.DownArrow)){
        transform.Translate(new Vector3 (0,-vel * Time.deltaTime,0));
      }*/
      if (Input.GetKeyDown(KeyCode.Space)){policia.AddForce(new Vector2(0,forca*Time.deltaTime),ForceMode2D.Impulse);}

      float H = Input.GetAxis("Horizontal");
      float V = Input.GetAxis("Vertical");
      transform.Translate(new Vector3(H*Time.deltaTime,V* Time.deltaTime,0));
    }
     // float H = Input.GetAxis("Mouse X");
      //float V = Input.GetAxis("Mouse Y");
      //transform.Translate(new Vector3(H*Time.deltaTime,V* Time.deltaTime,0));
    //}
    

  
}
