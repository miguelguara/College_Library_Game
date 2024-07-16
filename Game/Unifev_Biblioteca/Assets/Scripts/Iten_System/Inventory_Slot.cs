using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Slot : MonoBehaviour
{
    Item it;
    public Image Icon;
    GameObject ItemOBj;
    Transform Inst_pos;
    private void Awake()
    {
      Inst_pos = GameObject.Find("Drop_obj").GetComponent<Transform>();
    }

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
            Instantiate(ItemOBj,Inst_pos.position,Quaternion.identity);
            Inventory.IV.Remove_Item(it);
        }
    }
}
