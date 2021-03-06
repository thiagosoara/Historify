﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move_Mateu : MonoBehaviour
{
    public bool face = true;
    public Transform HeroiT;
    public float vel = 2.5f;
    public float forca = 6.5f;
    public Rigidbody2D HeroiRB;
    public bool liberapulo = false;
    public Animator anim;
    public bool vivo = true;
    void Start()
    {
        HeroiT = GetComponent<Transform>();
        HeroiRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
   
    void Update()
    {
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
                     anim.SetBool("Andando", true);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                    anim.SetBool("Idle", false);
                    anim.SetBool("Andando", true);
                }
                //MATEU PARADO
                else
                {
                    anim.SetBool("Idle", true);
                    anim.SetBool("Andando", false);
                }
            }
            //PULO DE MATEU
            if (vivo == true)
            {
                if (Input.GetKey(KeyCode.UpArrow) && liberapulo == true)
                {
                    HeroiRB.AddForce(new Vector2(0, forca), ForceMode2D.Impulse);
                    
                }
            }
        }
        
      

    }
    //VERIFICAÇÃO DA DIREÇÃO DE MATEU
    void Flip()
    {
        face = !face;
        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;
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
