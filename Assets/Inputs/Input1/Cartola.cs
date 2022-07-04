using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartola : MonoBehaviour
{

    public float vel = 3.0f;
    public bool liberaPer = false;
    public float distancia;
    public Transform Hero;
    public bool face = true;
    public Transform cartola;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(this.transform.position, Hero.transform.position);
        if (distancia == distancia)
        {
            anim.SetBool("Ido", false);
            anim.SetBool("Atacando", true);
            print("ok");
        }
        else
        {
            anim.SetBool("Ido", true);
            anim.SetBool("Atacando", false);
        }

        if ((Hero.transform.position.x > this.transform.position.x) && !face)
        {
            flip();
        }
        else if ((Hero.transform.position.x < this.transform.position.x) && face)
        {
            flip();
        }

        if ((liberaPer == true) && distancia > 2.8f)
        {
            if (Hero.transform.position.x < this.transform.position.x)
            {
                transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
                anim.SetBool("Ido", false);
                anim.SetBool("Correndo", true);

            }
            else if (Hero.transform.position.x > this.transform.position.x)
            {
                transform.Translate(new Vector2(vel * Time.deltaTime, 0));
                anim.SetBool("Ido", false);
                anim.SetBool("Correndo", true);

            }
            else
            {
                anim.SetBool("Ido", true);
                anim.SetBool("Correndo", false);
            }
        }
        void flip()
        {
            face = !face;
            //Vector3  scala = this.transform.localScale;
            //this.transform.localScale = scala;
            Vector3 scala = capataz.localScale;
            scala.x *= -1;
            capataz.localScale = scala;

        }
        void OnTriggerEnter2D(Collider2D outro)
        {
            if (outro.gameObject.CompareTag("Player"))
            {
                liberaPer = true;
            }
        }


    }
