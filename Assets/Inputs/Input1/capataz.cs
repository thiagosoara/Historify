using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class capataz : MonoBehaviour
{
public int vidaVilao1 = 100;
    public float Speed;
    private Transform Target;
    public float distancia;

    protected bool isMoving = false;
    protected Rigidbody2D rb2d;
    
    //vivo
    public Animator anim;
    public bool vilaoVivo = true;

    //contagem para o vilão seguir o heroi
    public float contagem = 1.0f;

    //dano 
    public float tempoDano = 1.0f;
    public bool vulneravel = false;
    protected SpriteRenderer sprite;

    //inicio
    public GameObject objeto;
    public bool pause = true;
    
    public GameObject graveto;
    public bool seguindo = false;

    //flip
    public Transform cap;
    public bool face = true;
    public Transform Hero;

    


    
    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim= GetComponent<Animator>();


    }

    void Update()
    {
          
        
        //libera a contagem para o vilão começa a seguir o heroi depois da historia
        if(objeto.activeInHierarchy == true){
            pause=true;
            //print("objeto ativo ");
        }
        else if (objeto.activeInHierarchy == false)
        {
            pause=false;
            //print("objeto desativado");
        }
        if (graveto.activeInHierarchy == false){
            seguindo=true;
            }


        //flip do capataz
        if((Hero.transform.position.x > this.transform.position.x) && !face)
        {
            flip();
        }
        else if ((Hero.transform.position.x < this.transform.position.x)&& face)
        {
            flip();
        }

        // vilão seguir heroi depois que a contagem acaba
        if (pause==false){

            if (seguindo==true){
                
         
            // vilão seguir Player 
            if(vilaoVivo==true){
                if (Vector2.Distance(transform.position, Target.position) > distancia){
                transform.position = Vector2.MoveTowards(transform.position,Target.position, Speed * Time.deltaTime);
                anim.SetBool("Idle", false);
                anim.SetBool("Correndo", true);}

                else{
                anim.SetBool("Idle", true);
                anim.SetBool("Correndo", false);}
            }
            


        }}
        //chicote
        if (pause==false && vilaoVivo==true){
            if (Vector2.Distance(transform.position, Target.position) < distancia){
            anim.SetBool("Idle", false);
            anim.SetBool("Chicote", true);
         }
         else {
            anim.SetBool("Idle", true);
            anim.SetBool("Chicote", false);
         }
         
         }

      
    }
    void flip(){
        face = !face;
        //Vector3  scala = this.transform.localScale;
        //this.transform.localScale = scala;
        Vector3 scala = cap.localScale;
        scala.x *= -1;
        cap.localScale = scala;

    }

 
    public void DamageEnemy(int damagePedra){
        vidaVilao1 -= damagePedra;
        StartCoroutine (Damage());
        if (vidaVilao1>1){
            vidaVilao1 = vidaVilao1-20;
            print("vida capataz 2 "+ vidaVilao1);
            }
        if(vidaVilao1<1){
            gameObject.SetActive(false);
        }
        
    }


    IEnumerator Damage(){

        for (float i=0f; i < 1f; i +=0.1f){
            vilaoVivo=false;
            anim.SetBool("Idle", true);
            anim.SetBool("Correndo", false);

            GetComponent<SpriteRenderer>().enabled = false;
            //sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            //sprite.enabled= true;
            yield return new WaitForSeconds(0.1f);

        }
        vilaoVivo = true;

    }
    

  
}

