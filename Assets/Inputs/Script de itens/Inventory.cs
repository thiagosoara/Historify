using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Armas[] Armas;
    public Consumiveis[] Vida;
    public GameObject TouchItem;

   public void DragItem( GameObject button)
   {
    TouchItem = button;
    TouchItem.transform.position = Input.mousePosition;
   }
   public void DropItem( GameObject button)
   {
    if(TouchItem != null)
    {
         Transform aux = TouchItem.transform.parent;
        TouchItem.transform.SetParent( button.transform.parent);
        button.transform.SetParent(aux);
       
    }
   }
}
