using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_naçu : MonoBehaviour
{
    public bool face = true;
    public Transform HeroiT;
    public float vel = 3.5f;
    public float forca = 7.5f;
    public Rigidbody2D HeroiRB;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        HeroiT = GetComponent<Transform>();
        HeroiRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !face)
            {
                Flip();
            }
            if (Input.GetKey(KeyCode.LeftArrow) && face)
            {
                Flip();
            }
            //MOVIMENTO DE MATEU

            if (Input.GetKey(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                     anim.SetBool("ido", false);
                     anim.SetBool("correr", true);
                }
            else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                    anim.SetBool("ido", false);
                    anim.SetBool("correr", true);
                }
                //MATEU PARADO
            else
                {
                    anim.SetBool("ido", true);
                    anim.SetBool("correr", false);
                }
            
        
    }
    void Flip()
    {
        face = !face;
        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;

    }
}
