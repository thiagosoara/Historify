using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
//referências.
public class EntitY
{
    [Header("Name")]
    public string Name;

    public int Level;

    [Header("Health")]

    public int currentHealth;

    public int maxHealth;

    [Header("Stamina")]

    public int currentStamina;

    public int maxStamina;

    [Header("Stats")]

    public int forca = 1;

    public int resistencia = 1;

    public int astucia = 1;

    public int dano = 1;

    public int defensa = 1;

    public float Vel = 2f;


}
