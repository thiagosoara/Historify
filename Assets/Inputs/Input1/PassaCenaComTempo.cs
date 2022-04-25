using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassaCenaComTempo : MonoBehaviour
{
    public GameObject panel;
    public bool passaCena = false;
    //public Text displayContagem;
    //public Text aviso;
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
            contagem -= Time.deltaTime;
            //print(contagem);
        }
        else
        {
            //displayContagem.text= "0";
            if (panel.activeInHierarchy == true){
            //print(passaCena);
            //Invoke ("NextLevel", 1f);  
                //print("panil"); 
                passaCena = true;
                //print("passa a cena "+ passaCena);
            }
        }

       if (passaCena ==true && panel.activeInHierarchy == false){
           print("ate aqui ok");
           Invoke ("NextLevel", 0f);
       }




        
    }
    void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        
    }
}
