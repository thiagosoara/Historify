using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colisao : MonoBehaviour
{
    public Image lifeBar;
    public Text txtVida;
    public int life = 20;
    public int ValorAtual = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("vida"))
        {
            if (ValorAtual < 100)
            {
                ValorAtual += life;
                lifeBar.fillAmount = (float)ValorAtual / 100;
                string temp = ValorAtual.ToString();
                txtVida.text = temp;

            }
            Destroy(outro.gameObject);
        }
    }
}
