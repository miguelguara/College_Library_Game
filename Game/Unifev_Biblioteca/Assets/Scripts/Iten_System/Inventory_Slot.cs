using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    Item it;
    public Image Icon;
    GameObject ItemOBj;
    Transform playerPO;

    public void fill_Slot(Item item)
    {
        it = item;
        Icon.enabled = true;
        Icon.sprite = it.sp;
        ItemOBj = it.go;
    }

    public void Clear_Slot()
    {
        Icon.sprite = null;
        Icon.enabled = false;
        ItemOBj = null;
    }

    public void S_item()
    {
        if (ItemOBj != null)
        {
            Instantiate(ItemOBj);
            Inventory.IV.Remove_Item(it);
        }
    }
}
