using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : Move_Mateu
{
    public Weapons WeaponsAtributes;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {

            Destroy(this.gameObject);
        }

    }
}
