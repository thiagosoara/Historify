using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botao_hero : MonoBehaviour
{
    [SerializeField]
    private int vel = 0;
    public bool face = true;
    public bool x = true;
    public bool y = false;
    public bool z = false;
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
        golpe();
    }
    void Flip()
    {
        face = !face;
        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;
    }
    public void direita()
    {
        vel = 3;
        x = false;
        y = true;
        if (!face)
        {
            Flip();
        }
    }
    public void esquerda()
    {
        vel = -3;
        x = false;
        y = true;
        if (face)
        {
            Flip();
        }

    }
    public void parado()
    {
        vel = 0;
        x = true;
        y = false;
        z = false;
        
    }
    public void mover()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));

    }
    public void animacao()
    {
        anim.SetBool("Idle", x);
        anim.SetBool("Andando", y);
        anim.SetBool("Chute", z);
    }
    public void golpe()
    {
        x= false;
        y = false;
        z = true;

    }
    /*void OnCollisionEnter2D(Collision2D outro)
    {
        if ((z == true) && (outro.gameObject.CompareTag("inimigo")))
        {
            Destroy(outro.gameObject);

        }
        
        
    }*/
}
