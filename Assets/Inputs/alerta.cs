using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alerta : MonoBehaviour
{
     public GameObject graveto;
     public GameObject pedra;





    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    void OnTriggerEnter2D(Collider2D outro){
        if (graveto.activeInHierarchy == true){
            if (outro.gameObject.CompareTag("Player")){
                //GetComponent<SpriteRenderer>().enabled = false;
                gameObject.SetActive(false);
                //print("graveto");
            }
        }
        if (pedra.activeInHierarchy == true){
            if (outro.gameObject.CompareTag("Player")){
                gameObject.SetActive(false);
            }
        }
    }

}

