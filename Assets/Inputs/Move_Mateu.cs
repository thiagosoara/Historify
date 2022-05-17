using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move_Mateu : MonoBehaviour
{
    public bool face = true;
    public Transform HeroiT;
    public float vel = 2.5f;
    public float forca = 1.2f;
    public Rigidbody2D HeroiRB;
    public bool liberapulo = false;
    public Animator anim;
    public bool vivo = true;
    // dano
    public int vida = 100;
    //Barra de vida
    public Image BarraDeVida;
    public Image cabeça;
    public Image BarraDeEstamina;
    public Image coraçao;
    public Image stamina; 


    //coleta itens
    public int pedra = 0; 
    public Text texPedra;

    //cria Pedra
    public GameObject balas;
    public GameObject BulletSpawn;
    public Transform bulletSpawn;

    //inicio
    public GameObject objeto;
    public bool pausa = true;

    //reniciar
    
    //public int reniciar = 0;

    public int tronco =0;


    


    


    void Start()
    {

        HeroiT = GetComponent<Transform>();
        HeroiRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        
    }

    // Update is called once per frame
   
    void Update()
    {

  
        //print(pedra);
        //print (vida);
        if (vivo==true)
        {
            //DIRECIONAMENTO DE MATEU
            if (Input.GetKey(KeyCode.RightArrow) && !face)
            {
                Flip();
            }
            if (Input.GetKey(KeyCode.LeftArrow) && face)
            {
                Flip();
            }
            //MOVIMENTO DE MATEU
            if (vivo == true)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                     anim.SetBool("Idle", false);
                     anim.SetBool("Corre", true);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                    anim.SetBool("Idle", false);
                    anim.SetBool("Corre", true);
                }
                //MATEU PARADO
                else
                {
                    anim.SetBool("Idle", true);
                    anim.SetBool("Corre", false);
                }
            }
            //PULO DE MATEU
            if (vivo == true)
            {
                if (Input.GetKey(KeyCode.UpArrow) && liberapulo == true)
                {
                    HeroiRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                    anim.SetBool("Pulo", true);
                    anim.SetBool("Idle", false);

                }
                else 
                {
                    anim.SetBool("Pulo", false);
                    anim.SetBool("Idle", true);
                
                
                }
                
            }
        }
        // jogar pedra
        if(pedra >=1){
        if (vivo == true){
            if (Input.GetKeyDown(KeyCode.Space)){
                anim.SetBool("Idle", false);
                anim.SetBool("Pedra", true);
                balas = Instantiate(balas, new Vector3(BulletSpawn.transform.position.x,BulletSpawn.transform.position.y,BulletSpawn.transform.position.z),transform.rotation);
                
                if(!face){
                    balas.transform.eulerAngles = new Vector3 (0,0,180);
                }


                pedra= pedra-1;
                texPedra.text = pedra.ToString();
            }
            else{
                anim.SetBool("Idle", true);
                anim.SetBool("Pedra", false);
            }

        }}

        else if (pedra ==0){
            anim.SetBool("Idle", true);
            anim.SetBool("Pedra", false);
        }
      

    }
    //VERIFICAÇÃO DA DIREÇÃO DE MATEU
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
    //VERIFICAÇÃO DE PULO
    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            liberapulo = true;
            anim.SetBool("Idle", true);
            anim.SetBool("Pulo", false);
        }
        if (outro.gameObject.CompareTag("inimigo")){
             if (vida>0){
                DamagePlayer();
                vida = vida-40;
                BarraDeVida.fillAmount= (float) vida/100;
                print(vida);

            }
        }



        //tronco
        if (outro.gameObject.CompareTag("tronco")){
            tronco=1;
            

        }

    }
    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            liberapulo = false;
            anim.SetBool("Idle", false);
            anim.SetBool("Pulo", true);

        }
    }
    // Dano ao heroi
    IEnumerator Damage(){
        for (float i=0f; i < 1f; i +=0.1f){
            GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds (0.1f);
            GetComponent<SpriteRenderer>().enabled = true;
            yield return new WaitForSeconds (0.1f);


        }
        
    }
    // função que vai causa o dano
    public void DamagePlayer(){
        StartCoroutine ( Damage());
    }

    
    //coleta itens
    void OnTriggerEnter2D(Collider2D outro){
        if (outro.gameObject.CompareTag("pedra")){
           pedra++;
           print(pedra);
           texPedra.text = pedra.ToString();
           Destroy(outro.gameObject); 


        }
         //dano no heroi
         
        if (outro.gameObject.CompareTag("Enemy")){
            //vida = vida-40;
            if (vida>0){
                DamagePlayer();
                vida = vida-40;
                BarraDeVida.fillAmount= (float) vida/100;
                print(vida);

            }
            else{
                //vivo=false;
                anim.SetBool("Idle", false);
                anim.SetBool("Morreu", true);
                vivo=false;
                Invoke ("ReloadLevel", 3f);
                if(vida<=0){
                    cabeça.fillAmount= 0;
                    BarraDeEstamina.fillAmount= 0;
                    coraçao.fillAmount=0;
                    stamina.fillAmount=0; 
                }
                print("morreu");
                }
        }
        if (outro.gameObject.CompareTag("Limbo")){
            Invoke ("ReloadLevel", 2f);
            }
    }
    //desativa a leitura quando o jogo for reniciado
    //jogar pedra pelo o botão na tela 


    //reniciar a fase 
    void ReloadLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    

    

    
}
