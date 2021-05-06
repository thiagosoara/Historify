using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botao_hero : MonoBehaviour
{
    [SerializeField]
    private float vel = 0;
    public bool face = true;
    public bool x = true;
    public bool y = false;
    public bool z = false;
    public bool f = false;
    public bool g = false;
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
        }
    }
    void Flip()
    {
        face = !face;
        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;
    }
    //ANIMAÇÃO MOVIMENTO PARA A DIREITA
    public void direita()
    {
        vel = 3.5f;
        x = false;
        y = true;
        z = false;
        if (!face)
        {
            Flip();
        }
    }
    //ANIMAÇÃO MOVIMENTO PARA A ESQUERDA
    public void esquerda()
    {
        vel = -3.5f;
        x = false;
        y = true;
        z = false;
        if (face)
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
        z = false;
        
    }
    //ANIMAÇÃO GOLPES
    public void golpe()
    {
        x = false;
        y = false;
        z = true;

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
        anim.SetBool("Golpe", z);
        anim.SetBool("Facao", f);
        anim.SetBool("Garruncha", g);
    }
    
    /*void OnCollisionEnter2D(Collision2D outro)
    {
        if ((z == true) && (outro.gameObject.CompareTag("inimigo")))
        {
            Destroy(outro.gameObject);

        }
        
        
    }*/
}
