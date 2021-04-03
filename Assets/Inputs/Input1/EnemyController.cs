using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected int health;
    public float distanceAttack;
    public int speed;

    protected bool isMoving = false;

    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;

    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        anim = GetComponent <Animator> ();
        sprite = GetComponent<SpriteRenderer> ();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform> ();
    }

    protected float PlayerDistance (){
        return Vector2.Distance(player.position, transform.position);

    }
    protected void Flip(){
        sprite.flipX = !sprite.flipX;
        speed*= -1; 
    }
    protected virtual void Update(){
        float distance = PlayerDistance ();
        isMoving = (distance <= distanceAttack);   

        if (isMoving){
            if((player.position.x > transform.position.x && sprite.flipX)||
            (player.position.x < transform.position.x && !sprite.flipX)){
                Flip();
            }
        } 
    }
    //dano 
    public void DamageEnemy (int damageBullet){
        health -= damageBullet;

        StartCoroutine (Damage());

        if (health < 1)
        {
            Destroy(gameObject);
        }

    }
    // Mudança de cor quando o vilão leva dano 
    IEnumerator Damage(){
        sprite.color= Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;

    }
}
