using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class segundos : MonoBehaviour
{
    public Text displayContagem;
    public Text aviso;
    public float contagem = 1.0f;
    public GameObject objeto;
    // pausa(p)
    public bool p = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objeto.activeInHierarchy == true){
            p=true;
            //print("objeto ativo ");
        }
        else if (objeto.activeInHierarchy == false)
        {
            p=false;
            //print("objeto desativado");
        }
        if(p==false){
         if(contagem > 0.0f)
        {
            aviso.text= "Capataz se aproximando:";
            contagem -= Time.deltaTime;
            displayContagem.text = contagem.ToString("F0") + "s";
        }
        else
        {
            displayContagem.text= "0";
        }
    }
    }
}
