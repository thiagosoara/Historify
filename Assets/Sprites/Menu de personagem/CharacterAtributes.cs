using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CharacterAtributes : MonoBehaviour
{

    [Header("Mateu")]
   public string Mateu;
   
   [Header("Vida")]
   public int currentVida;
   public int maxvida;

   [Header("Stamina")]

   public int currentStamina;

   public int maxStamina;

   [Header("Status")]

   public int forca = 1;
   public int resistencia = 1;
   public int dano = 1;
   public int defesa = 1;
   public float velocidade = 2f;
}
