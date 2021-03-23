using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//referências.
public class EntitY
{
    [Hearder("Name")]
    public string Name;

    [Hearder("Health")]

    public int currentHealth;

    public int maxHealth;

    [Hearder("Stamina")]

    public int currentStamina;

    public int maxStamina;

    [Hearder("Stats")]

    public int forca;

    public int resistencia;

    public int dano = 1;

    public int defensa = 1;

    public float Vel = 2f;


}
