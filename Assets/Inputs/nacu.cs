using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nacu : MonoBehaviour
{
    public float speed = 2f; // Velocidade de movimento do inimigo
    public Transform pointA; // Ponto de início da patrulha
    public Transform pointB; // Ponto final da patrulha
    public Animator anim;
    public GameObject apresentacao;
    public GameObject escolha;
    public GameObject Player1;
    public GameObject Player2;



    private bool movingRight = true; // Variável que controla a direção de movimento do inimigo

    // Update é chamado uma vez por quadro
    void Update()
    {
        // Se o inimigo estiver se movendo para a direita
        if (movingRight)
        {
            // Move o inimigo para a direita ao longo do eixo X
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            // Se o inimigo atingiu o ponto final da patrulha
            if (transform.position.x >= pointB.position.x)
            {
                // Inverte a direção de movimento do inimigo
                movingRight = false;
                // Inverte a direção em que o inimigo está olhando
                transform.localScale = new Vector3(-1f, 1f, 1f);

            }
            anim.SetBool("ido", false);
            anim.SetBool("correr", true);
        }
        // Se o inimigo estiver se movendo para a esquerda
        else
        {
            // Move o inimigo para a esquerda ao longo do eixo X
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

            // Se o inimigo atingiu o ponto de início da patrulha
            if (transform.position.x <= pointA.position.x)
            {
                // Inverte a direção de movimento do inimigo
                movingRight = true;
                // Inverte a direção em que o inimigo está olhando
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
            anim.SetBool("ido", false);
            anim.SetBool("correr", true);
        }
    }

    // Detecta colisões com outros objetos
    void OnTriggerEnter2D(Collider2D other)
    {
        // Se o inimigo colidiu com o jogador
        if (other.CompareTag("Player"))
        {
            // Executa a lógica do jogo correspondente (por exemplo, reduzindo a saúde do jogador)
            // ...
            if(apresentacao.activeInHierarchy == false){
                apresentacao.SetActive(true);
            }
            // Faz o inimigo parar de se mover por 2 segundos antes de atacar novamente
            StartCoroutine(StopForSeconds(2));
        }
    }

    // Faz o inimigo parar de se mover por um determinado número de segundos
    IEnumerator StopForSeconds(float seconds)
    {
        // Para o movimento do inimigo
        speed = 0f;
        // Espera o número de segundos especificado
        yield return new WaitForSeconds(seconds);
        // Restaura o movimento do inimigo
        if (apresentacao.activeInHierarchy== true){
            apresentacao.SetActive(false);
        }
        if(apresentacao.activeInHierarchy == false){
            if (escolha.activeInHierarchy == false){
                escolha.SetActive(true);
                Player1.SetActive(false);
                Player2.SetActive(false);
            }
        }
        speed = 0f;
    }
}
