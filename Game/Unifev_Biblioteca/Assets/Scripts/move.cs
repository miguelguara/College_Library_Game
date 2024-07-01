using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    float Speed;
    private Dialogue_Control DC;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();
     DC = FindObjectOfType<Dialogue_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dr = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f).normalized;
        if (DC.Can_Move)
        {
            anim.SetFloat("Speed", dr.magnitude);
            anim.SetFloat("H", dr.x);
            anim.SetFloat ("V", dr.y);
            transform.Translate(dr * Speed * Time.deltaTime, Space.Self);
            if (dr != Vector3.zero)
            {
                anim.SetFloat("Idle H", dr.x);
                anim.SetFloat("Idle V", dr.y);
            }
        }

        
    }
}
