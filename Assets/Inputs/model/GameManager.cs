using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Int32 CalculeHealth(Player player)
    {
        //formula de atributo.
        Int32 result = (player.entity.resistencia*10) + (player.entity.Level*4)+10;
        return result;
        
    }
}
