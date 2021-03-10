using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //int estado = 2;

    //int x=0;


    // Start is called before the first frame update
    void Start()
    {
        /*if (estado==1){print("Mate o heroi");}
        else if (estado==2){print("Mate o heroi se puder");}
        else if (estado ==3){print("Corra agora");}
        else{print("nenhum estado selecionado");}*/

        //switch
        /*switch (estado){
            case 1:
                print("Mate o heroi");
                break;
            case 2:
                print("Mate o heroi se puder");
                break;
            case 3:
                print("Corra agora");
                break;
            default:
                print("nenhum estado selecionado");
                break;
        }*/

        //utilizando for 
        /*for (int x=0;x<=10;x++){
            print(x);
        }*/

        //while
        /*while(x<=10){
            print(x);
            x++;
        }*/
        //do/while
        /*do{
            print("oi pessoal");
            x++;
        }while(x<=10);*/

        // vetores (listas)
        /*int [] array= new int [10];
        for (int t=0; t<=9;t++){
            array[t]=t +1;
        }
        foreach (int numero in array){
            print(numero);
        }*/

        //Matrizes
        /*int [,] matriz=new int [2,2];
        //matriz[0,0]=1;
        //matriz[0,1]=2;
        //matriz[1,0]=3;
        //matriz[1,1]=4;
        //print(matriz[0,1]);
        int valor=1;
        for (int linhas=0; linhas<=1;linhas++){
            for(int colunas=0; colunas<=1; colunas++){
                matriz[linhas,colunas]=valor;
                valor++;
            }
        }

          for (int linhas=0; linhas<=1;linhas++){
            for(int colunas=0; colunas<=1; colunas++){
                print(linhas+":"+colunas+"="+matriz[linhas,colunas]);
            }
        }*/
        // listas
        List<int> lista= new List<int>();
        lista.Add(100);
        lista.Add(200);
        print(lista[0]+" "+ lista[1]);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
