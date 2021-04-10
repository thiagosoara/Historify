using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequirHeroi : MonoBehaviour
{
    public int health;
    public float Speed;
    private Transform Target;
    public float distancia;

    protected bool isMoving = false;
    protected Rigidbody2D rb2d;
    

    public Animator anim;
    public bool vivo;

    //public float contagem = 1.0f;
    
    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim= GetComponent<Animator>();
    }

    void Update()
    {
            
        if (Vector2.Distance(transform.position, Target.position) > distancia){
        transform.position = Vector2.MoveTowards(transform.position,Target.position, Speed * Time.deltaTime);
            if (vivo == true){
                anim.SetBool("Idle", false);
                anim.SetBool("Correndo", true);}
            
            else{
                anim.SetBool("Idle", true);
                anim.SetBool("Correndo", false);}
        } 
        if (Vector2.Distance(transform.position, Target.position) == distancia){
            if (vivo == true){
                    anim.SetBool("Idle", false);
                    anim.SetBool("Chicote", true);
                }
                else{
                    anim.SetBool("Idle", true);
                    anim.SetBool("Chicote", false);
                }
        }


      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().perdeVida();
        }
    }
}
