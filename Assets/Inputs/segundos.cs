using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class segundos : MonoBehaviour
{
    public Text displayContagem;
    public Text aviso;
    public float contagem = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
