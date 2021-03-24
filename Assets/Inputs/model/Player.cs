using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameManager manager;
    public EntitY entity;


    [Header("Player UI")]

    public Slider Health;

    public Slider Stamina;

    public Slider Exp;


    void Start()
    {
        entity.maxHealth = manager.CalculeHealth(this);
        EntitY.currentHealth = entity.maxHealth;
        EntitY.currentStamina = entity.maxStamina;

        Health.value = entity.maxHealth;
        Health.maxHealth = entity.maxHealth;

        Stamina.value = entity.maxStamina;
        Stamina.value = entity.maxStamina;

        Exp.value = 0;

    }
     private void Update()
     {
         Health.value = entity.currentHealth;

         Stamina.value = entity.currentStamina;

         

     
     }
     

}
