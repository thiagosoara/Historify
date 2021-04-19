using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverHorei : MonoBehaviour
{
    /*public float maxSpeed;
    public float jumpForce;

    private bool grounded;
    private bool jumping;

    private Rigidbody2D rb2d;
    private Animator anim;
    private SpriteRenderer sprite;

    public Transform groundCheck;
    public Transform bulletSpawn;
    public GameObject bulletObject;
    public float fireRate;
    public float nextFire;

    void Awake(){
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("chao"));
        if (Input.GetButtonDown("Jump")&& grounded){
            jumping = true;
        }
        
        if (Input.GetButton ("Fire1") && Time.time > nextFire){
            Fire(); }
        
    }
    void FixedUpdate()
    {
        float move = Input.GetAxis ("Horizontal");
        
        anim.SetFloat("Speed", Mathf.Abs (move));

        rb2d.velocity = new Vector2 (move * maxSpeed, rb2d.velocity.y);
        if ((move > 0f && sprite.flipX)||(move < 0f && sprite.flipX)){
            Flip ();
        }
        
        
        if (jumping){
            rb2d.AddForce( new Vector2 (0f, jumpForce));
            jumping = false;
        }
        anim.SetBool("JumpFall", rb2d.velocity.y !=0);
    }
    void Flip () {
        sprite.flipX = !sprite.flipX;
    }

      void Fire(){
            anim.SetTrigger("Fire");
            nextFire = Time.time + fireRate;
            GameObject cloneBullet = Instantiate (bulletObject, bulletSpawn.position, bulletSpawn.rotation);
      }*/
}
