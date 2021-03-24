using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequirHeroi : MonoBehaviour
{
    public float Speed;
    private Transform Target;

    public Animation anim;

    public bool vivo;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim= GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,Target.position, Speed * Time.deltaTime);
    }
}
