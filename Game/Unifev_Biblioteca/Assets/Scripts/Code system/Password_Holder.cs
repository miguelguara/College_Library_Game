using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password_Holder : MonoBehaviour
{
    public GameObject item;
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
            Instantiate(item,new Vector3(transform.position.x,transform.position.y +1f,0f),Quaternion.identity);
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
