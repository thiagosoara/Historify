using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    private int vidas = 2;

    // Start is called before the first frame update
    void Awake()
    {
       if (gm == null)
       {
           gm = this;
           DontDestroyOnLoad(gameObject);

       }
       else {
           Destroy(gameObject);
       }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetVidas (int vida)
    {
        vidas += vida;
    
    }
    public int GetVidas()
    {
        return vidas;
    }
}
