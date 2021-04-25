using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalas : MonoBehaviour
{
    public float forca = 1.5f;
    public int damage;


    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector2 (forca * Time.deltaTime,0));
        transform.Translate(Vector2.right * forca * Time.deltaTime);
       
        
    }
    void OnTriggerEnter2D(Collider2D outro){
        if (outro.gameObject.CompareTag("Enemy")){
            sequirHeroi enemy = outro.GetComponent<sequirHeroi>();
            if (enemy !=null){
                enemy.DamageEnemy (damage);
            }

        }

    }
}
