using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sequirHeroi : MonoBehaviour
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

    
    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim= GetComponent<Animator>();


    }

    void Update()
    {
        // vilão seguir heroi depois que a contagem acaba

         if(contagem > 0.0f)
        {
            contagem -= Time.deltaTime;
            
        }
        else
        {
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


        }
        //chicote
        if (vilaoVivo==true){
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

    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().perdeVida();
        }
    }*/
    /*IEnumerator Damage(){
        for (float i=0f; i < 1f; i +=0.1f){
            sprite.enabled = false;
            yield return new WaitForSeconds (0.1f);
            sprite.enabled= true;
            yield return new WaitForSeconds (0.1f);


        }}*/

    void OnTriggerEnter2D(Collider2D outro){
        if (outro.gameObject.CompareTag("pedraCriada")){
          for (float i=0f; i < 1f; i +=0.1f){
              //anim.SetBool("Idle", true);
              //anim.SetBool("Correndo", false);
              vilaoVivo = false;
              new WaitForSeconds (0.1f);
              gameObject.SetActive(false);
              new WaitForSeconds (0.1f);
              gameObject.SetActive(true);
              print("i"+i);
                

          }
          }
          print ("seguindo novamente");
          vilaoVivo = true;
          Update();

            /*if(vidaVilao1 >=1)
            {
                for (float i=0f; i < 1f; i +=0.1f){
                    anim.SetBool("Idle", true);
                    anim.SetBool("Correndo", false);
                    vidaVilao1 = vidaVilao1 -10;
                    vilaoVivo=false;
                    vulneravel= true;
                    StartCoroutine ( Damage());
                    print("vilão " + vidaVilao1);
                }


            if (vulneravel== true){
                vilaoVivo = true;
                Update();
                print ("seguir novamente vilão");
            }
                    //vilaoVivo = true;
                     //Update();
                    //anim.SetBool("Idle", false);
                    //anim.SetBool("Correndo", true);
                   // print ("seguir novamente vilão");

            }*/

            //else{
                //animação de morrente por pedra 
                //vilaoVivo=false;
               // anim.SetBool("Idle", false);
               // anim.SetBool("Correndo", true);
               // print ("Vilão Morreu");
          //  }


           //pedra++;
           //texPedra.text = pedra.ToString();
           //Destroy(outro.gameObject); 
        
        }
}
