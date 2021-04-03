using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : Move_Mateu
{
    //variaveis do tiro
    public Transform bulletSpawn;
    public float fireRate;
    public float nextFire;
    public GameObject bulletObject;
    protected SpriteRenderer sprite;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton ("Fire1") && Time.time > nextFire){
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
        anim.SetTrigger("Fire");
        nextFire = Time.time + fireRate;
        GameObject cloneBullet = Instantiate (bulletObject, bulletSpawn.position, bulletSpawn.rotation);
        
        if (sprite.flipX){
            cloneBullet.transform.eulerAngles = new Vector3 (0,0,180);}
        

    }
}
