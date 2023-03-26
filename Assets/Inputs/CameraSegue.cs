using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public GameObject player;
    public GameObject HeroiN;
    public float canVel = 0.25f;
    private bool segueHeroi;
    public Vector3 ultimoAlvoPos;
    public Vector3 ultimoAlvoPosN;
    public Vector3 velAtual;

    // Start is called before the first frame update
    void Start()
    {
        segueHeroi = true;
        ultimoAlvoPos = player.transform.position;

        ultimoAlvoPosN = HeroiN.transform.position;
    }
     void FixedUpdate()
    {
        if (segueHeroi)
        {
            if (player.transform.position.x >= transform.position.x)
            {
                Vector3 novaCamPos = Vector3.SmoothDamp(transform.position, player.transform.position, ref velAtual, canVel);
                transform.position = new Vector3(novaCamPos.x, novaCamPos.y, transform.position.z);
                ultimoAlvoPos = player.transform.position;
            }
            if(player.activeInHierarchy == false){
                if (HeroiN.transform.position.x >= transform.position.x){
                    Vector3 novaCamPos = Vector3.SmoothDamp(transform.position, HeroiN.transform.position, ref velAtual, canVel);
                    transform.position = new Vector3 (novaCamPos.x, novaCamPos.y, transform.position.z);
                    ultimoAlvoPosN = HeroiN.transform.position;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
