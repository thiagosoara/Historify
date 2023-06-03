using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public GameObject player;
    public GameObject HeroiN;
    public float canVel = 0.25f;
    private bool segueHeroi;
    private Vector3 ultimoAlvoPos;
    private Vector3 velAtual;

    void Start()
    {
        segueHeroi = true;
        ultimoAlvoPos = player.transform.position;
    }

    void FixedUpdate()
    {
        if (segueHeroi)
        {
            Vector3 alvoPos;
            if (player.activeInHierarchy)
            {
                alvoPos = player.transform.position;
            }
            else
            {
                alvoPos = HeroiN.transform.position;
            }

            Vector3 novaCamPos = Vector3.SmoothDamp(transform.position, alvoPos, ref velAtual, canVel);
            transform.position = new Vector3(novaCamPos.x, novaCamPos.y, transform.position.z);

            ultimoAlvoPos = alvoPos;
        }
    }
}
