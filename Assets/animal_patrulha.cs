using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal_patrulha : MonoBehaviour
{
    public float speed;
    public float perimetri;

    bool isRight= true;
    public transform groundCheck;

    // Update is called once per frame
    void Update()
    {
       transfor.translate(Vector2.right*speed*Time.deltaTime); 

       RaycastHit2D ground= Physics2D.Raycast(groundCheck.position, Vector2.donw, distance);
       if( ground == false)
       {
           if(isRight == true);
           {
               transform.eulerAngle = new Vector2 (0,0,0);
               isRight = false;
           }else;
           {
               transform.eulerAngle = new Vector2 (0,180,0);
               isRight = true;
           }
       }
    
    }
}
