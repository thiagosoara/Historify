using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativanacu : MonoBehaviour

{
    public GameObject apresentacao;
    public GameObject escolha;

    public GameObject chuva;
    public GameObject NacuAndando;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
         if (NacuAndando.activeInHierarchy==false)
        {
             StartCoroutine(StopForSeconds(2));
        }
    }
    IEnumerator StopForSeconds(float seconds)
    {


        // Espera o número de segundos especificado
        yield return new WaitForSeconds(seconds);
        // Restaura o movimento do inimigo
        if (apresentacao.activeInHierarchy== true){
            apresentacao.SetActive(false);
        }
        if(apresentacao.activeInHierarchy == false){
            if (escolha.activeInHierarchy == false){
                escolha.SetActive(true);
                chuva.SetActive(false);
                
            }
        }

    }
    
}
