using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivaDesativa : MonoBehaviour
{
    public GameObject Imagem19;
    public GameObject texto19;

    public GameObject Imagem;
    public GameObject texto;

    public GameObject Imagem20;
    public GameObject texto20;

    public GameObject Imagem21;
    public GameObject texto21;

    public GameObject Imagem22;

    public float desativa = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
        //RectTransform.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(desativa > 0.0f)
        {
            desativa -= Time.deltaTime;
            texto19.SetActive(true);
            
        }
        else
        { //imagem numero 19
            if(Imagem19.activeInHierarchy == true){
    
            Imagem19.SetActive(false);
            texto19.SetActive(false);

            desativa = 10;
            }

            if (Imagem.activeInHierarchy == true && Imagem19.activeInHierarchy == false){
                if(desativa > 0.0f){
                        desativa -= Time.deltaTime;
                        texto.SetActive(true);
                    }
                else{
                    Imagem.SetActive(false);
                    texto.SetActive(false);
                    desativa = 14;
                }

            }
            //imagem numero 20 
            if (Imagem20.activeInHierarchy == true && Imagem.activeInHierarchy == false){
                 if(desativa > 0.0f){
                        desativa -= Time.deltaTime;
                        texto20.SetActive(true);
                    }
                else{
                    Imagem20.SetActive(false);
                    texto20.SetActive(false);
                    desativa = 20;
                }
            }
            //imagem numero 21
            if (Imagem20.activeInHierarchy == false && Imagem21.activeInHierarchy == true){
                 if(desativa > 0.0f){
                        desativa -= Time.deltaTime;
                        texto21.SetActive(true);
                    }
                else{
                    Imagem21.SetActive(false);
                    texto21.SetActive(false);
                    desativa = 3;
                    
                }
            }
            //imagem numero 22
            if (Imagem21.activeInHierarchy == false && Imagem22.activeInHierarchy == true){
                 if(desativa > 0.0f){
                        desativa -= Time.deltaTime;
                    }
                else{
                    Imagem22.SetActive(false);
                    desativa = 5;
                }
            }

        }
        
        
    }

}
