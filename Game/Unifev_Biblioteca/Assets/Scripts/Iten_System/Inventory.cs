using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory IV;
    public int Q_item;
    public List<Item> itens = new List<Item>();
    UI_Update UI_p;
    private void Awake()
    {
        IV = this;
        UI_p = FindObjectOfType<UI_Update>();
    }

    public void Add_Item(Item item)
    {
        if(itens.Count < Q_item) 
        {
            itens.Add(item);
        }
        UI_p.Update_UI();
    }
    public void Remove_Item(Item item)
    {
        itens.Remove(item);
        UI_p.Update_UI();
    }
}
