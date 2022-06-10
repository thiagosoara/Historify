using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tronco : MonoBehaviour
{
    public GameObject gravetoDesativa;
    public GameObject troncos;
    public bool animacao = false;
  
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D outro){
        if (gravetoDesativa.activeInHierarchy == true){
             if (outro.gameObject.CompareTag("Player")){
                 animacao= true;

                 print(animacao);

             }

        }
        if(animacao == true)
        {
            if(troncos.activeInHierarchy == true){
                troncos.SetActive(false);
                
            }
        }
     

    }

}
