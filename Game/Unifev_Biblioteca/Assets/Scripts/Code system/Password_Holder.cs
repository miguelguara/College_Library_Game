using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password_Holder : MonoBehaviour
{
    //The puzzle Itens
    public GameObject[] item;
    [SerializeField]
    private GameObject Interact_Shine;
    bool open = false;
    Code_Controler code_controler;
    [SerializeField] int c1, c2, c3;
    Password_Holder ph;
    void Start()
    {
        ph = this;
        code_controler = FindObjectOfType<Code_Controler>();
    }

    // Update is called once per frame
    void Update()
    {
      open = code_controler.verificar_Code(c1 , c2, c3,open);
        if(open)
        {
            ph.enabled = false;
            Destroy(Interact_Shine);
            Instantiate(item[0], new Vector3(transform.position.x-1f, transform.position.y + 1f, 0f), Quaternion.identity);
            Instantiate(item[1], new Vector3(transform.position.x + 1f, transform.position.y + 1f, 0f), Quaternion.identity);
        }
    }

    private void OnMouseDown()
    {
        if (!open)
        {
            code_controler.ativar_Code();
        }
    }
}
