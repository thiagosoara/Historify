using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alerta : MonoBehaviour
{
    private bool liberaPer;




    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D (Collider2D alerta){
        if (alerta.gameObject.CompareTag("Player"))
             liberaPer = true;

    }


}

