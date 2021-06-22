using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capataz1 : MonoBehaviour
{
    public float vel = 3.0f;
    public bool liberaPer = false;
    public float distancia;
    public Transform Hero;
    public bool face = true;
    public Transform capataz; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance (this.transform.position, Hero.transform.position);

        if((Hero.transform.position.x > this.transform.position.x) && !face)
        {
            flip();
        }
        else if ((Hero.transform.position.x < this.transform.position.x)&& face)
        {
            flip();
        }

        if ((liberaPer == true) && distancia > 2.8f)
        {
            if (Hero.transform.position.x < this.transform.position.x)
            {
                transform.Translate (new Vector2 (-vel *  Time.deltaTime, 0));
                
            }
            else if (Hero.transform.position.x > this.transform.position.x){
                transform.Translate(new Vector2 (vel * Time.deltaTime, 0));
            
            }
            
        }
    }
    void flip(){
        face = !face;
        //Vector3  scala = this.transform.localScale;
        //this.transform.localScale = scala;
        Vector3 scala = capataz.localScale;
        scala.x *= -1;
        capataz.localScale = scala;

    }
    void OnTriggerEnter2D (Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Player"))
        {
            liberaPer = true;
        }
    }
}
