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
    }
    public void direitaN(){

        vel = 3.5f;
        x = false;
        y = true;
    }
    public void paradoN(){
        vel = 0;
        x = true;
        y = false;
    }

    void animacaoNacu(){
        anim.SetBool("ido", x);
        anim.SetBool("correr", y);
    }

    public void mover(){
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));
    }
}
