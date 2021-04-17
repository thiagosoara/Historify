using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : Move_Mateu
{
    //variaveis do tiro
    /*public Transform bulletSpawn;
     public Animator anim;
    //public float fireRate;
    //public float nextFire;
    //public GameObject bulletObject;
    //protected SpriteRenderer sprite;

    //public bool podeAtirar;
    public GameObject bala;

    void Start()
    {
        //podeAtirar = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)){
         //   GameObject objeto = Instantiate (bala, transform.position,transform.rotation);
         //   objeto.GetComponent<Rigidbody>().AddForce (Vector3.forward * 100);
       // }
        if (Input.GetMouseButtonDown(0)){
            Fire(); }
    }
    void Flip () {
        sprite.flipX = !sprite.flipX;

        if (!sprite.flipX){
            bulletSpawn.position = new Vector3(this.transform.position.x - 0.97f, bulletSpawn.position.y, bulletSpawn.position.z);}
        else{
            bulletSpawn.position = new Vector3(this.transform.position.x + 0.97f, bulletSpawn.position.y, bulletSpawn.position.z);}
    }

     void Fire(){
        anim.SetBool("Idle", false);
        anim.SetBool("Pedra", true);
        //nextFire = Time.time + fireRate;
        GameObject objeto = Instantiate (bala, bulletSpawn.position, bulletSpawn.rotation);
        objeto.GetComponent<Rigidbody>().AddForce (Vector3.forward * 100);
        
        //if (sprite.flipX){
           // objeto.transform.eulerAngles = new Vector3 (0,0,180);}
        

    }*/
}
