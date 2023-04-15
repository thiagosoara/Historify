using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botão_nacu : Move_naçu
{
    public Transform HeroiT;
    public Animator anim;
    public Rigidbody2D HeroiRB;

    //velocidade
    private float vel = 0;
    // direção
    public bool face = true;
    //x = ido
    public bool x = true;

    //y = andando
    public bool y = false;

    //pl= pulo
    public bool pl = false;

    // Start is called before the first frame update
    void Start()
    {
        HeroiT = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        HeroiRB = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        mover();
        animacaoNacu();
        
    }
  
    public void esquerdaN(){
        vel = -3.5f;
        x = false;
        y = true;
        pl=false;

        if (face)
        {
            Flip();
        }

    }
    public void direitaN(){
        vel = 3.5f;
        x = false;
        y = true;
        pl=false;

        if (!face)
        {
            Flip();
        }


    }
    public void paradoN(){
        vel = 0;
        x = true;
        y = false;
        pl= false;

    }

    void animacaoNacu(){
        anim.SetBool("ido", x);
        anim.SetBool("correr", y);
        anim.SetBool("pulo", pl);


    }

    public void mover(){
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
    }
    void Flip(){
        face = !face;
        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;
    }
    // ANIMAÇÃO DE PULO
    public void PuloNacu(){
        if (liberapulo==true){
            forca = 6f;
            HeroiRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
            pl = true;
            y=false;
            x= false;
           
        }
        if(liberapulo==false){
            pl=false;
            y=false;
            x=true;

        }



    }
}

