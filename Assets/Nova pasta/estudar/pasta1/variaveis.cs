using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variaveis : MonoBehaviour{

    //int carteira = 100;
    /*float carteira2 = 10.5f;
    bool teste = false;
    string texto;*/

    //int num1,num2,num3,resultado;

    //int carteira;
    //int numero1=10;
    //int numero2=20;

    int moedasHeroi=20;
    int valorVida=100;
    String result;
    // Start is called before the first frame update
    void Start()
    {
        /*print(carteira);
        print(carteira2);
        print (teste);
        texto = carteira.ToString();
        print (texto + 1);*/
        
        //num1=10;
        //num2=20;
        //num3=30;
        //resultado= num1 + num2+ num3;
        //carteira=10;
        //carteira +=2;

        //print(!(numero1 == numero2));
        //print(numero1 != numero2);
        result=(moedasHeroi>=valorVida)?"Posso compra a vida":"Não tenho dinheiro";
        print(result);
        
    

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
