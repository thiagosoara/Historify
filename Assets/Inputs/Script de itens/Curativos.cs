using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curativos : MonoBehaviour
{
     public int vida;

    private void OnCollisionEnter2D(Collision2D colision)
    {

        if(colision.gameObject.name.Equals("babosa"))
        {
            Destroy(colision.gameObject);
            vida++;
        }
    }
}
