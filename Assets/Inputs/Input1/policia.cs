using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policia : EnemyController
{
    // Start is called before the first frame update
    void Start()
    {
        health = 2;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        /*float distance = PlayerDistance();
        isMoving = (distance <= distanceAttack);
        
        
        if(isMoving){
            if((player.position.x > transform.position.x && sprite.flipX)||
            (player.position.x < transform.position.x && !sprite.flipX)){
                Flip();
            }
        }*/
        //Debug.Log (distance);

    }
    void FixedUpdate() {
        if (isMoving) {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        anim.SetBool("Idle", false);
        anim.SetBool("Correndo", true);
        print("animação");
        
        }
        else{
                anim.SetBool("Idle", true);
                anim.SetBool("Correndo", false);}
        
    }
}
