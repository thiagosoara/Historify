using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public CharacterAtributes atributo;
    public Slider vida;

    public Slider Stamina;
    
    public Slider exp;

    void Start()
    {
        atributo.currentVida = atributo.maxvida;
        atributo.currentStamina = atributo.maxStamina;

        vida.value = atributo.maxvida;
        Stamina.value = atributo.maxStamina;

        exp.value = 0;
    }
    private void Update()
    {
        vida.value = atributo.currentVida;
        Stamina.value= atributo.currentStamina;
    }


}
