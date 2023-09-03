using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    public AudioSource audioSorceMusicaDeFundo;
    public AudioClip[] musicasDeFundo;
    // Start is called before the first frame update
    void Start()
    {
        //modulo de selecao de musicas por fase jogavel
        AudioClip musicasDeFundoDessaFase = musicasDeFundo[0];
        audioSorceMusicaDeFundo.clip = musicasDeFundoDessaFase;
        audioSorceMusicaDeFundo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
