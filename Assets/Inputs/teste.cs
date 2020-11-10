using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teste : MonoBehaviour
{
    public Image lifeBar;
    public Text txtVida;
    public int ValorAtual = 100;
    public int dano = 15;
    public int energia = 10;
    public int life = 20;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AtualizaText();
    }
    public void VidaBarMenos()
    {
        if (ValorAtual > 0)
        {
            ValorAtual -= dano;
            lifeBar.fillAmount = (float)ValorAtual / 100;
            string temp = ValorAtual.ToString();
            txtVida.text = temp;

        }
    }
    public void VidaBarMais()
    {
        if (ValorAtual > 0)
        {
            ValorAtual += energia;
            lifeBar.fillAmount = (float)ValorAtual / 100;
            string temp = ValorAtual.ToString();
            txtVida.text = temp;

        }
    }
    void AtualizaText()
    {
        if (ValorAtual >= 100)
        {
            ValorAtual = 100;
            txtVida.text = ValorAtual.ToString();
        }
        if (ValorAtual <= 0)
        {
            ValorAtual = 0;
            txtVida.text = ValorAtual.ToString();
        }
    }
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("vida"))
        {
            ValorAtual = ValorAtual + life;
            Destroy(outro.gameObject);
        }
    }
}
