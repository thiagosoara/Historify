using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int experiencia = 0;
    public int nivel = 1;
    public int forca = 10;
    public int vida = 100;
    
    public Slider xpBar;
    public Text nivelText;

    void Start()
    {
        xpBar.maxValue = GetMaxXPForLevel(nivel);
        xpBar.value = experiencia;
        nivelText.text = "Nível: " + nivel;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EliminarInimigo();
        }
    }

    void EliminarInimigo()
    {
        int xpGanho = 10; // XP ganho ao eliminar um inimigo (aumente conforme necessário)
        experiencia += xpGanho;
        xpBar.value = experiencia;

        if (experiencia >= GetMaxXPForLevel(nivel))
        {
            nivel++;
            nivelText.text = "Nível: " + nivel;
            forca += 5; // Aumenta a força ao subir de nível
            vida += 20; // Aumenta a vida ao subir de nível
            experiencia = 0;
            xpBar.maxValue = GetMaxXPForLevel(nivel);
            xpBar.value = experiencia;
        }
    }

    int GetMaxXPForLevel(int level)
    {
        return level * 100; // Exemplo: 100 de XP necessário para o nível 1, 200 para o nível 2, etc.
    }
}
