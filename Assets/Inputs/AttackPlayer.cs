using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    private bool atacando;
    public Animato animator;

    public Transform ataquePoint;

    public float ataqueRanger= 0.5f;

    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atacando = Input.GetbuttonDown("Fire2");
        if(atacando == true){
            Ataque()
        }
        void Ataque()
        {
            animator.SetTrigger("ataque")
        }
    }
}
