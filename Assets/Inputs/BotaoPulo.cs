using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotaoPulo : MonoBehaviour
{
    public int forca = 0;
    public bool liberapulo = false;
    public Rigidbody2D HeroiRB;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        HeroiRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pulo()
    {
        forca = 7;
        acao();
    }
    public void acao()
    {
        if (liberapulo == true)
        {
            HeroiRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);

        }
    }
    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            liberapulo = true;
           anim.SetBool("Idle", true);
            anim.SetBool("Pulo", false);
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
}
