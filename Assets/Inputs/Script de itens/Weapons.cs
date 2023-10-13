using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="WeaponsAtributes", menuName = "Weapon/New Weapon")]
public class Weapons : ScriptableObject
{
   public string name;
   public Sprite icone;
   public int dano;
   public float alcance;
}
