using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunter : MonoBehaviour
{
    public Transform player; // Referência ao jogador
    public float moveSpeed = 5.0f; // Velocidade de movimento
    public float rotationSpeed = 2.0f; // Velocidade de rotação
    public GameObject gunPrefab; // Prefab da arma
    public int initialAmmo = 10; // Munição inicial

    private Transform gunSpawnPoint;
    private int currentAmmo;

    void Start()
    {
        gunSpawnPoint = transform.Find("GunSpawnPoint");
        currentAmmo = initialAmmo;
    }

    void Update()
    {
        // Rotação para encarar o jogador
        Vector3 playerDirection = player.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(playerDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Movimento em direção ao jogador
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        // Disparar quando o jogador estiver à vista
        if (IsPlayerInSight())
        {
            if (currentAmmo > 0)
            {
                Shoot();
            }
        }
    }

    bool IsPlayerInSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.position - transform.position, out hit))
        {
            if (hit.transform == player)
            {
                return true;
            }
        }
        return false;
    }

    void Shoot()
    {
        // Lógica de disparo (instanciação de projéteis, controle de munição, causar dano ao jogador, etc.)
    }

    void Die()
    {
        // Lógica para quando o caçador morrer (deixar arma e munição)
        Instantiate(gunPrefab, transform.position, Quaternion.identity);
        // Deixe munição com a arma
        gunPrefab.GetComponent<Weapon>().SetAmmo(currentAmmo);
        Destroy(gameObject);
    }
}
