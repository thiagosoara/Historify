using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botao_hero : Move_Mateu
{
    [SerializeField]
    private float vel = 0;
    public bool face = true;
    //x = idle
    public bool x = true;

    //y = andando
    public bool y = false;

    //z = golpe 
    //public bool z = false;

    //f=fação
    public bool f = false;

    // g =garruncha
    public bool g = false;

    //p = atira pedra 
    public bool p = false;

    //pl= pulo
    public bool pl = false;

    // b= baixando
    public bool b = false;

    // a = andando agachando
    public bool a = false;

    //l= levantado
    public bool l = false;


    //levantado
    public bool levantado = true;


    public Transform HeroiT;
    public Animator anim;
    public Rigidbody2D HeroiRB;
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
        
        //print("vida de mateu"+vivo);
        animacao();
        mover();


        if (Input.GetKey(KeyCode.F))
        {
            f = true;
        }
        else if (Input.GetKey(KeyCode.G))
        { 
            g = true;
        }
            
        else
        {
            f = false;
            g = false;
            p = false;
            pl = false;
            a = false;
            l= false;
            b= false;
            
            


        }
    }
    void Flip()
    {
        face = !face;
        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;

         //flip para jogar a pedra
        if (!face){
            bulletSpawn.position = new Vector3 (this.transform.position.x - 0.36f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
        else{
            bulletSpawn.position = new Vector3 (this.transform.position.x + 0.36f, bulletSpawn.position.y, bulletSpawn.position.z);
        }
    }
    //ANIMAÇÃO MOVIMENTO PARA A DIREITA
    public void direita()
    {
        if (vivo==true && levantado==true){
            vel = 3.5f;
            x = true;
            y = true;
            a= false; 
        }

        if (vivo==true && levantado==false){
            vel = 2.0f;
            x = true;
            a = true;
            y= false;
        }
       
        //z = false;

        if (vivo==true && !face)
        {
            Flip();
        }
    }
    //ANIMAÇÃO MOVIMENTO PARA A ESQUERDA
    public void esquerda()
    {
        if (vivo==true && levantado==true){
        vel = -3.5f;
        x = true;
        y = true;
        }

        if (vivo==true && levantado==false){
            vel = -2.0f;
            x = true;
            a = true;
            y= false;
        }

        //z = false;
        if (vivo==true && face)
        {
            Flip();
        }

    }
    //ANIMAÇÃO PARADO
    public void parado()
    {
        vel = 0;
        x = true;
        y = false;
        if(levantado==false){
            vel = 0;
            x=false;
            a=false;
            b=true;
        }
        //z = false;
        
    }
    public void paradoAgachado(){}
    //ANIMAÇÃO GOLPES
    public void golpe()
    {
        x = false;
        y = false;
        //z = true;

    }
    public void mover()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));

    }
    //VARIAVEL BASE DAS ANIMAÇÕES
    public void animacao()
    {
        anim.SetBool("Idle", x);
        anim.SetBool("Corre", y);
        anim.SetBool("Pedra", p);
        anim.SetBool("Pulo", pl);
        anim.SetBool("agachando",a);
        anim.SetBool("Levantar",l);
        anim.SetBool("agachado",b);
        //anim.SetBool("andaAgachando",a);
        //anim.SetBool("Golpe", z);
        //anim.SetBool("Facao", f);
        //anim.SetBool("Garruncha", g);
    }
    // ANIMAÇÃO DE MATEU JOGANDO PEDRA
    public void jogarPedra(){
        if (vivo==true && pedra>0){
            //anim.SetBool("Idle", false);
            //anim.SetBool("Pedra", true);
            x= true;
            p= true;
            balas = Instantiate(balas, new Vector3(BulletSpawn.transform.position.x,BulletSpawn.transform.position.y,BulletSpawn.transform.position.z),transform.rotation);

            if(!face){
                    balas.transform.eulerAngles = new Vector3 (0,0,180);
                }
            
            pedra= pedra-1;
            texPedra.text = pedra.ToString();    
            
        }
        else{
            x = true;
            p = false;
            //anim.SetBool("Idle", true);
            //anim.SetBool("Pedra", false);
            
        }
      
    }
    // ANIMAÇÃO DE PULO
    public void Pulo(){
        if (vivo==true && liberapulo==true){
        forca = 10f;
        HeroiRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
        pl = true;
        }
        if(vivo==true && liberapulo==false){
            pl=false;
        }
        //print ("pular");
    }
    //ANIMAÇÃO DE LEVANTAR 
    public void levantar(){
        if (vivo==true){
            levantado = true;

                vel = 0;
                x = true;
                l= true;
                y = false;   
                a = false;
        }
        
        //print("O personagem deve se levantar");
    }
    //ANIMAÇÃO PARA SE ABAIXA
    public void abaixa(){
        if (vivo==true && levantado == true){
            b=true;

        }
        levantado = false;

       
        
        


        //print("O personagem deve se abaixa-se");
    }
    /*void OnCollisionEnter2D(Collision2D outro)
    {
        if ((z == true) && (outro.gameObject.CompareTag("inimigo")))
        {
            Destroy(outro.gameObject);

        }
        
        
    }*/
        
}
