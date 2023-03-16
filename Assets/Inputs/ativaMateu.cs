using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativaMateu : MonoBehaviour
{
    public GameObject nacu;
    public GameObject escolha;
    public GameObject chuva;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (escolha.activeInHierarchy == true){
             //mateu.SetActive(false);
        }
    }



    public void escolherMateu () {
        if(nacu.activeInHierarchy == true){
            nacu.SetActive(false);
            escolha.SetActive(false);
            chuva.SetActive(true);
        }
    }
}
