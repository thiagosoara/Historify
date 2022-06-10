using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troncoAtive : MonoBehaviour
{
    public GameObject gravetoAtiva;
    // tc = tronco
    public GameObject tc;
    public bool ativa = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D outro){
        if (gravetoAtiva.activeInHierarchy == true){
             if (outro.gameObject.CompareTag("Player")){
                 ativa = true;

                 print(ativa);

             }

        }
        if(ativa == true)
        {
            if(tc.activeInHierarchy == false){
                tc.SetActive(true);
                
            }
        }
     

    }
}
