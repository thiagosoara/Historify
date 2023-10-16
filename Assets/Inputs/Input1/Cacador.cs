using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacador : MonoBehaviour
{
    public Transform player;
    public float attackRange = 10.0f;
    public float attackCooldown = 2.0f;
    public GameObject weaponPrefab;
    public int initialAmmo = 15;

    private Animator animator;
    private int currentAmmo;
    private float lastAttackTime;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentAmmo = initialAmmo;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            // Ataque ao jogador
            Attack();
        }
    }

    void Attack()
    {
        if (currentAmmo > 0)
        {
            // Ativar a animação de tiro
            animator.SetTrigger("tiro");

            // Lógica para causar dano ao jogador
            // Subtrair munição
            currentAmmo--;

            // Atualizar o tempo do último ataque
            lastAttackTime = Time.time;
        }
        else
        {
            // Ativar a animação de recarga
            animator.SetTrigger("reload");
            // Recarregar a arma
            currentAmmo = initialAmmo;
        }
    }

   
}

