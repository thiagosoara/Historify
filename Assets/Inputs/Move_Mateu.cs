using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Mateu : MonoBehaviour
{
    public bool face = true;
    public Transform HeroiT;
    public float vel = 2.5f;
    public float forca = 6.5f;
    public Rigidbody2D HeroiRB;

    void Start()
    {
        HeroiT = GetComponent<Transform>();
        HeroiRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !face)
        {
            Flip();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && face)
        {
            Flip();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(vel * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-vel * Time.deltaTime, 0));
        }

    }
    void Flip()
    {
        face = !face;
        Vector3 scala = HeroiT.localScale;
        scala.x *= -1;
        HeroiT.localScale = scala;
    }
}
