﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaDesativa : MonoBehaviour
{
    public GameObject objeto;
    // Start is called before the first frame update
    void Start()
    {
        if(objeto.activeInHierarchy == true){
            print("objeto ativo ");
        }
        //RectTransform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
