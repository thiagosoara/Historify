using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequirHeroi : EnemyController
{
    public int health;
    public float Speed;
    private Transform Target;
    public float distancia;
    //public bool face = true;

    protected bool isMoving = false;
    protected Rigidbody2D rb2d;
    

    public Animator anim;

    public bool vivo;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, Target.position) > distancia){
        transform.position = Vector2.MoveTowards(transform.position,Target.position, Speed * Time.deltaTime);}


       /*// flip
        if((Target.transform.position.x > this.transform.position.x) && !face)
        {
            flip();
        }
        else if ((Target.transform.position.x < this.transform.position.x)&& face)
        {
            flip();
        }


         if (Target.transform.position.x < this.transform.position.x)
            {
                transform.Translate (new Vector2 (-Speed *  Time.deltaTime, 0));
                
            }
            else if (Target.transform.position.x > this.transform.position.x){
                transform.Translate(new Vector2 (Speed * Time.deltaTime, 0));
                
            }*/
            
    }

    /*void flip ()
    {
        face = !face;
        Vector3 scala = this.transform.localScale;
        scala.x += -1;
        this.transform.localScale = scala;

    }*/
    // Quando o vilão chegar perto do heroi
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerLife>().perdeVida();
        }
    }
}
