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

    
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim= GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) > distancia){
        transform.position = Vector2.MoveTowards(transform.position,Target.position, Speed * Time.deltaTime);}


      
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().perdeVida();
        }
    }
}
