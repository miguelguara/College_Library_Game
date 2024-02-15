using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Update : MonoBehaviour
{
    public Inventory_Slot[] slots;
    private Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void Update_UI()
    {
      for (int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.itens.Count)
            {
                slots[i].fill_Slot(inventory.itens[i]);
            }
            else
            {
                slots[i].Clear_Slot();
            }
        }
    }
}
