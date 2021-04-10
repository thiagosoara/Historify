using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaBalas : MonoBehaviour
{
    public GameObject balas;
    public GameObject BulletSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Instantiate(balas, new Vector3(BulletSpawn.transform.position.x,BulletSpawn.transform.position.y,BulletSpawn.transform.position.z),transform.rotation);
        }
    }
}
