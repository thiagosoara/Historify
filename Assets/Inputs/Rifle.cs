using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab do projetil
    public Transform firePoint; // Ponto de origem do disparo
    public float fireRate = 0.5f; // Taxa de disparo (tiros por segundo)
    public float projectileSpeed = 10.0f; // Velocidade do projetil
    public int maxAmmo = 30; // Munição máxima
    public float reloadTime = 2.0f; // Tempo de recarga em segundos

    private int currentAmmo;
    private float nextFireTime;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            if (currentAmmo > 0)
            {
                Shoot();
                nextFireTime = Time.time + 1 / fireRate;
            }
            else
            {
                // Chame uma função para recarregar
                Reload();
            }
        }
    }

    void Shoot()
    {
        // Crie o projetil
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Defina a velocidade do projetil
        rb.velocity = firePoint.forward * projectileSpeed;

        // Reduza a munição
        currentAmmo--;

        // Destrua o projetil após um período de tempo (se não atingir nada)
        Destroy(projectile, 2.0f);
    }

    void Reload()
    {
        // Inicie a animação de recarga ou outra lógica de recarga
        Debug.Log("Recarregando...");

        // Aguarde o tempo de recarga e recarregue a munição
        currentAmmo = maxAmmo;
    }

    public void SetAmmo(int ammo)
    {
        currentAmmo = ammo;
    }
}
