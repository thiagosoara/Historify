using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "enemyAtributes", menuName="Enemy/New Enemy")]
public class EnimyObject : ScriptableObject
{
    public string name;
    public int health;
    public float speed;
    public int xpGanho;
}
