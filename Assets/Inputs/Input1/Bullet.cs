using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private float timeDestroy;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        timeDestroy = 1.0f;
        Destroy (gameObject, timeDestroy);
        damage = 1 ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D (Collider2D other){
        if(other.CompareTag ("Enemy")){
            EnemyController enemy = other.GetComponent<EnemyController>();
            if (enemy !=null){
                enemy.DamageEnemy(damage);

            }

        }
        Destroy(gameObject);
    }
}
