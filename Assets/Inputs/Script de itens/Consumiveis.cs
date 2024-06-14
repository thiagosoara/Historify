using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumivel", menuName = "Consumivel/New Consumivel", order = 1)]
public class Consumiveis : ScriptableObject

{
    public string id;
    public int Cura;
    public Sprite iImagem;
}
