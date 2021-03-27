using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraDeVida : MonoBehaviour
{
    public Image lifeBar;
    public int valorAtual=100;
    public int dano = 10; 
    public int energia =10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VidaBarMenos()
    {
        if (valorAtual > 0)
        {
            valorAtual -= dano;
            lifeBar.fillAmount = (float)valorAtual/100;
        }
    }
}
