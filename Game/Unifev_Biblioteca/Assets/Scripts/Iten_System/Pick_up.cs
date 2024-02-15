using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_up : MonoBehaviour
{
    public Item Itm;
    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
        {
           Inventory.IV.Add_Item(Itm);
            Destroy(gameObject);
        }
    }
}
