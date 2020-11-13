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
    public Transform HeroiT;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        HeroiT = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animacao();
        mover();
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
    }
    public void mover()
    {
        transform.Translate(new Vector2(vel * Time.deltaTime, 0));

    }
    public void animacao()
    {
        anim.SetBool("Idle", x);
        anim.SetBool("Andando", y);
    }
}
